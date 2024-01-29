using System.Linq.Expressions;




var o = new Person { age = 21, name = "Roman", skills = "fishing" };


UpdateProperties(o, x => x.age, x => x.skills, x => x.name);


Console.ReadLine();

void UpdateProperties<TEntity>(TEntity obj, params Expression<Func<TEntity, object>>[] propertySelectors)
{
	foreach (var propertySelector in propertySelectors)
	{
		if (!(propertySelector.Body is MemberExpression memberExpression))
		{
			// Handle UnaryExpression (conversion)
			if (propertySelector.Body is UnaryExpression unaryExpression && unaryExpression.Operand is MemberExpression operand)
			{
				memberExpression = operand;
			}
			else
			{
				throw new ArgumentException("Invalid property selector. Please use a lambda expression that selects a property.");
			}
		}

		var propertyName = memberExpression.Member.Name;
		var func = propertySelector.Compile();
		var propertyValue = func(obj);

		Console.WriteLine($"{propertyName} - {propertyValue}");
	}

}

class Person
{
	public string? name { get; set; }
	public int? age { get; set; }
	public string? skills { get; set; }
}

