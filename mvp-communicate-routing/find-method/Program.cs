using find_method;
using System.Reflection;

var myInstance = new MyClass();

// при старте можно проиндексировать методы
// тогда при работе просто проходить по методам... А лучше 
// экземпляр класса контроллера будем регистрировать при старте.
// экземпляр унаследован от IComp, имеет имя
// имеет методы, помеченные аттрибутом метода
var methodInfo = GetMethodByAttributeName(myInstance, "MethodA");
if (methodInfo != null)
{
	Console.WriteLine($"Found method: {methodInfo.Name}");
}
else
{
	Console.WriteLine("Method not found.");
}

Console.ReadLine();

static MethodInfo GetMethodByAttributeName(object obj, string attributeName)
{
	if (obj == null) throw new ArgumentNullException();

	return obj.GetType()
			  .GetMethods()
			  .FirstOrDefault(method => method.GetCustomAttributes<NamedAttribute>()
											 .Any(attr => attr.Name == attributeName));
}