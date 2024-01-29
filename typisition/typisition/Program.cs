

SomeObject[] objects = new SomeObject[]
{
			new SomeObject { Name = "Object1", Category = 1 },
			new SomeObject { Name = "Object2", Category = 2 },
			new SomeObject { Name = "Object3", Category = 1 },
			new SomeObject { Name = "Object4", Category = 3 },
	// Add more SomeObject instances if needed
};

int[] uniqueCategories = objects.Select(obj => obj.Category).Distinct().ToArray();

// Print out the unique categories to verify
Console.WriteLine("Unique categories:");
foreach (int category in uniqueCategories)
{
	Console.WriteLine(category);
}


Console.ReadLine();

public class SomeObject
{
	public string Name { get; set; }
	public int Category { get; set; }
}