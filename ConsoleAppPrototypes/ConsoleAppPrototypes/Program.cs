// See https://aka.ms/new-console-template for more information

using System.Collections.Generic;

go();

Console.ReadLine();



void go()
{
	string[] array = { "rus", "eng", "tur", "kzt" };

	var list = array.ToList();

	for (int i = 0; i < list.Count - 1; i++)
		for (int j = i + 1; j < list.Count; j++)
            Console.WriteLine($"{list[i]} - {list[j]}");
}