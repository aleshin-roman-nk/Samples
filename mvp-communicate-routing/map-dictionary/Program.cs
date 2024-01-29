





using map_dictionary;
using System.Reflection;

var inst = new SampleClass();

var targetType = typeof(SampleClass);
var methodsWithAttributes = GetMethodsMarkedWithAttribute(targetType);
foreach (var pair in methodsWithAttributes)
{
	Console.WriteLine($"Attribute Name: {pair.Key}, Method Name: {pair.Value.Name}");
	pair.Value.Invoke(inst, null);
}


Console.ReadLine();


static Dictionary<string, MethodInfo> GetMethodsMarkedWithAttribute(Type targetType)
{
	Dictionary<string, MethodInfo> methodDictionary = new Dictionary<string, MethodInfo>();

	foreach (MethodInfo methodInfo in targetType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
	{
		MyAttribute attribute = methodInfo.GetCustomAttribute<MyAttribute>();
		if (attribute != null)
		{
			methodDictionary.Add(attribute.Name, methodInfo);
		}
	}

	return methodDictionary;
}