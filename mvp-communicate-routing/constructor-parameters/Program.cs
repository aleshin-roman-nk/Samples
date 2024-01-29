

using System;
using System.Reflection;


Type type = typeof(MyClass);

foreach (ConstructorInfo ctor in type.GetConstructors())
{
	Console.WriteLine($"Constructor: {ctor.ToString()}");
	ParameterInfo[] parameters = ctor.GetParameters();

	foreach (ParameterInfo param in parameters)
	{
		Console.WriteLine($"\tParameter Name: {param.Name}, Type: {param.ParameterType}");
	}
}


Console.ReadLine();

public class MyClass
{
	public MyClass() { }
	public MyClass(int param1) { }
	public MyClass(string param2, double param3) { }
}