// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Options;
using PlayEF_Sqlite;
using PlayEF_Sqlite.Repos;

AppData db = new AppData();
ThoughtRepo thoughtRepo = new ThoughtRepo(db);

var res = thoughtRepo.GetThoughtsWOCard();

foreach (var item in res)
{
	Console.WriteLine(item.text);
}

Console.ReadLine();

