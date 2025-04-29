namespace WebApiLesson.ImplementRepo.EF
{
	using System.Collections.Concurrent;
	using System.Linq.Expressions;
	using CoreServices.Dto;
	using Microsoft.EntityFrameworkCore;

	public static class DbContextUpdateEntityExtension
	{
		private static readonly ConcurrentDictionary<string, Action<object, object>> _mappingCache = new();

		public static async Task<TDbEntity> UpdateFromDtoAsync<TDbEntity, TDtoEntity>(
			this DbContext db,
			TDtoEntity dto
		)
			where TDbEntity : class
			where TDtoEntity : IUpdatableEntityDto
		{
			var entityType = typeof(TDbEntity);
			var dtoType = typeof(TDtoEntity);
			var idPropertyName = "Id";

			// Найти трекаемую сущность
			var trackedEntity = db.ChangeTracker.Entries<TDbEntity>()
				.FirstOrDefault(e =>
				{
					var idProp = entityType.GetProperty(idPropertyName);
					var currentId = (int)idProp.GetValue(e.Entity);
					return currentId == dto.id;
				});

			TDbEntity entity;

			if (trackedEntity != null)
			{
				entity = trackedEntity.Entity;
			}
			else
			{
				entity = await db.Set<TDbEntity>().FindAsync(dto.id);

				if (entity == null)
					throw new Exception($"Entity {entityType.Name} with Id {dto.id} not found.");
			}

			// Обновляем значения
			var mapAction = GetOrCreateMapAction<TDbEntity, TDtoEntity>();
			mapAction(entity, dto);

			// Проставляем только те свойства, которые не null
			var entry = db.Entry(entity);
			foreach (var prop in dtoType.GetProperties())
			{
				if (prop.Name == idPropertyName)
					continue;

				var value = prop.GetValue(dto);
				if (value != null)
				{
					entry.Property(prop.Name).IsModified = true;
				}
			}

			return entity;
		}

		private static Action<object, object> GetOrCreateMapAction<TDbEntity, TDtoEntity>()
		{
			var key = $"{typeof(TDbEntity).FullName}|{typeof(TDtoEntity).FullName}";

			if (_mappingCache.TryGetValue(key, out var action))
				return action;

			var entityType = typeof(TDbEntity);
			var dtoType = typeof(TDtoEntity);

			var entityParam = Expression.Parameter(typeof(object), "entity");
			var dtoParam = Expression.Parameter(typeof(object), "dto");

			var entityVar = Expression.Variable(entityType, "typedEntity");
			var dtoVar = Expression.Variable(dtoType, "typedDto");

			var blockExpressions = new List<Expression>
		{
			Expression.Assign(entityVar, Expression.Convert(entityParam, entityType)),
			Expression.Assign(dtoVar, Expression.Convert(dtoParam, dtoType))
		};

			foreach (var dtoProp in dtoType.GetProperties())
			{
				if (dtoProp.Name == "Id")
					continue;

				var entityProp = entityType.GetProperty(dtoProp.Name);
				if (entityProp == null || !entityProp.CanWrite)
					continue;

				// if (dto.Property != null) entity.Property = dto.Property;
				var condition = Expression.NotEqual(
					Expression.Property(dtoVar, dtoProp),
					Expression.Constant(null)
				);

				var assign = Expression.Assign(
					Expression.Property(entityVar, entityProp),
					Expression.Property(dtoVar, dtoProp)
				);

				blockExpressions.Add(Expression.IfThen(condition, assign));
			}

			var body = Expression.Block(new[] { entityVar, dtoVar }, blockExpressions);

			var lambda = Expression.Lambda<Action<object, object>>(body, entityParam, dtoParam);

			var compiled = lambda.Compile();
			_mappingCache[key] = compiled;
			return compiled;
		}
	}

}
