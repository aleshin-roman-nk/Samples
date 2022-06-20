// See https://aka.ms/new-console-template for more information
using ManyToManyLesson;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

/*
 * Провести эксперимент, чтобы слова можно было грузануть через joining table.
 * 
 */

var db = new AppData("data.db");

IQueryable<word> words = db.words.Where(x => x.matrix_id == 1);
db.words.Add(new word { name = "where", matrix_id = 1});
db.SaveChanges();

print(words.ToArray());

//print(getMatrix(1, db));

Console.WriteLine("Ok");

Console.ReadLine();

void print(object o)
{
    var j = JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
    Console.WriteLine(j);
}

word getWord(int id, AppData db)
{
    return db.words.FirstOrDefault(x => x.id == id);
}

matrix? getMatrix(int id, AppData db)
{
    return db.matrices
        .Include(x => x.words)
        .Where(x => x.id == id)
        .Select(x => new matrix { descr = x.descr, words = x.words })
        .FirstOrDefault();
}