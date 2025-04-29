using CoreServices;
using CoreServices.Dto;
using CoreServices.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApiLesson.ImplementRepo.EF
{
	public class AnimalRepo : IAnimalRepo
	{
		private readonly AppDbContext db;

		public AnimalRepo(AppDbContext db)
		{
			this.db = db;
		}

		public Task<Animal> Create(CreateAnimalDto a)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Animal>> GetAll()
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Animal>> GetAllAsync()
		{
			return await db.Animals.ToListAsync();
		}

		public async Task<Animal> GetAsync(Animal a)
		{
			//var entry = db.Animals.Attach(new Animal { Id = 1});
			//var res = await db.Animals.FindAsync(1);

			//var entry = db.Animals.Attach(new Animal { Id = 1 });
			//entry.Entity.Name = "rqqqq-qq-qqqq";
			//Console.WriteLine(db.SaveChanges());
			//var res = await db.Animals.FindAsync(1);

			var res = await db.Animals.FindAsync(a.Id);

			if(res == null) throw new ArgumentNullException(nameof(res));

			if(a.isBird != null) res.isBird = a.isBird;
			if(a.Description != null) res.Description = a.Description;
			if(a.Name != null) res.Name = a.Name;

			Console.WriteLine(db.SaveChanges());

			return res;
		}

		public Task<Animal> Update(UpdateAnimalDto a)
		{
			throw new NotImplementedException();
		}
	}
}
