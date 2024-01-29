using System;
using System.Linq;



// Assume items is an array of Item objects
Item[] items = new Item[]
{
			// Initialize with some items
			new Item { Name = "Item1", Price = 100.0m, Date = new DateTime(2023, 11, 1) },
			new Item { Name = "Item2", Price = 150.0m, Date = new DateTime(2023, 11, 1) },
			new Item { Name = "Item3", Price = 200.0m, Date = new DateTime(2023, 11, 2) },
	// Add more Item instances if needed
};

// Group items by Date and sum their Price
GroupedItem[] groupedItems = items
	.GroupBy(item => item.Date)
	.Select(group => new GroupedItem
	{
		Date = group.Key,
		TotalPrice = group.Sum(item => item.Price)
	})
	.ToArray();

// Output the results to verify
foreach (var groupedItem in groupedItems)
{
	Console.WriteLine($"Date: {groupedItem.Date.ToShortDateString()}, Total Price: {groupedItem.TotalPrice}");
}


Console.ReadLine();

public class Item
{
	public string Name { get; set; }
	public decimal Price { get; set; }
	public DateTime Date { get; set; }
}

public class GroupedItem
{
	public DateTime Date { get; set; }
	public decimal TotalPrice { get; set; }
}