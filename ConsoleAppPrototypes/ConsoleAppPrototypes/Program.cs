// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using AutoMapper;
using AutoMapper.Internal;


// Initialize AutoMapper
var config = new MapperConfiguration(cfg =>
{
	cfg.CreateMap<StudentDto, Student>();
});

IMapper mapper = config.CreateMapper();

// Source object
var studentDto = new StudentDto
{
	Id = 1,
	FirstName = "John",
	LastName = "Doe",
	Age = 25
};

// Mapping
var student = mapper.Map<Student>(studentDto);

// Output mapped object
//Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Age: {student.Age}");
Console.WriteLine($"Student: {student.FirstName}, Age: {student.Age}");

var tool = new PropertyUpdaterTools<StudentDto>();

tool.Update(studentDto, x => x.FirstName);

Console.ReadLine();

void go()
{
	string[] array = { "rus", "eng", "tur", "kzt" };

	var list = array.ToList();

	for (int i = 0; i < list.Count - 1; i++)
		for (int j = i + 1; j < list.Count; j++)
            Console.WriteLine($"{list[i]} - {list[j]}");
}


public class StudentDto
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int Age { get; set; }
}

public class Student
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	//public string LastName { get; set; }
	public int Age { get; set; }
}

class MyProperty<TPropType>
{
	public MyProperty(TPropType v, string n)
	{
		Value = v;
		PropName = n;
	}

	public TPropType Value { get; set; }
	public string PropName {  get; set; }
}

internal class PropertyUpdaterTools<TEntity>
	where TEntity : class
{
	public void Update<TValue>(TEntity entity, Expression<Func<TEntity, TValue>> propertySelector)
	{
		if (entity == null)
		{
			throw new ArgumentNullException(nameof(entity));
		}

		if (propertySelector == null)
		{
			throw new ArgumentNullException(nameof(propertySelector));
		}

		if (!(propertySelector.Body is MemberExpression memberExpression))
		{
			throw new ArgumentException("Invalid property selector. Please use a lambda expression that selects a property.");
		}

		var propertyName = memberExpression.Member.Name;
		var propertyValue = propertySelector.Compile()(entity);

		// Now you can use propertyName and propertyValue as needed
		Console.WriteLine($"Updating {propertyName} with value {propertyValue}...");

		// You can update the property here, e.g., using reflection or your custom logic
	}




	//public string GetPropertyName<TProperty>(Expression<Func<TEntity, TProperty>> prop)
	//{
	//	if (prop.Body is MemberExpression memberExpression)
	//	{
	//		return memberExpression.Member.Name;
	//	}
	//	else
	//	{
	//		throw new ArgumentException("Expression must be a member access expression");
	//	}
	//}

	//public string GetPropertyValue<TProperty>(Expression<Func<TEntity, TProperty>> prop)
	//{
	//	if (prop.Body is MemberExpression memberExpression)
	//	{
	//		return prop.Compile()();
	//	}
	//	else
	//	{
	//		throw new ArgumentException("Expression must be a member access expression");
	//	}
	//}
}