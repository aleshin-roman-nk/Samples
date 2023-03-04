// See https://aka.ms/new-console-template for more information


Stack<int> s = new Stack<int>();
s.Push(0);
s.Push(1);
s.Push(2);
s.Push(3);
s.Push(4);

foreach (var item in s)
{
    Console.WriteLine(item);
}

Console.WriteLine("===");

Console.WriteLine(s.ToArray()[0]);

Stack<int> s2 = new Stack<int>();
s2.Push(100);
Console.WriteLine(s2.Pop());
Console.WriteLine($"stack peek {s2.Peek()}");

//while(s.Count > 0)
//    Console.WriteLine(s.Pop());

Console.ReadLine();