// See https://aka.ms/new-console-template for more information
using WordsTestProto;

Console.WriteLine("Hello, World!");

WordTest test = new WordTest();

test.StartTest();

while (!test.TestIsOver())
{
    Console.Write($"Что азначает `{test.CurrentQuestion()}` > ");

    var answer = Console.ReadLine();

    test.CheckAndNext(answer);
}

Console.WriteLine($"Всего очков {test.TotalLastTest()}");
var passed = test.TotalLastTest() < 75.0m ? "провален" : "пройден";
Console.WriteLine($"тест {passed}");

Console.ReadLine();