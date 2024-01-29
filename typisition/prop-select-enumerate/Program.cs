

// Create a list and add selected property names to it
List<string> selectedProperties = new List<string>();
selectedProperties.Add(nameof(Person.name));
selectedProperties.Add(nameof(Person.age));

// Convert the list to an array
string[] propertiesArray = selectedProperties.ToArray();

// Print the array elements
foreach (var property in propertiesArray)
{
	Console.WriteLine(property);
}


Console.ReadLine();


class Person
{
	public int id { get; set; }
	public string name { get; set; }
	public int age { get; set; }
}