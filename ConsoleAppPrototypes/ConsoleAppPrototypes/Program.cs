// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;

List<DateTime> intervals = new List<DateTime>();

//int now = 0;

//for (int i = 0; i < 10; i++)
//{

//}

DateTime dt = new DateTime(2023, 9, 9, 0, 0, 0);

intervals.Add(dt);
intervals.Add(dt = dt.AddDays(1));
intervals.Add(dt = dt.AddDays(1));
intervals.Add(dt = dt.AddDays(2));
intervals.Add(dt = dt.AddDays(2));
intervals.Add(dt = dt.AddDays(3));
intervals.Add(dt.AddDays(10));

foreach (var item in intervals)
{
    Console.WriteLine($"{item} | {item.DayOfWeek}");
}


Console.ReadLine();



void go()
{
	string[] array = { "rus", "eng", "tur", "kzt" };

	var list = array.ToList();

	for (int i = 0; i < list.Count - 1; i++)
		for (int j = i + 1; j < list.Count; j++)
            Console.WriteLine($"{list[i]} - {list[j]}");
}