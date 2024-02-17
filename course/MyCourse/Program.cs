using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MyCourse.Data;

var dataContext = new DataContextDapper();

var dt = dataContext.LoadDataSingle<DateTime>("select getdate()");

System.Console.WriteLine(dt);

var cmtr = new Computer{
CPUCores = 4,
HasLTE = false,
HasWifi = false,
Motherboard = "ZZZ345",
Price = 1200,
ReleaseDate = DateTime.Now,
VideoCard = "3060 RTX"
};

string sql1 = @"insert into TutorialAppSchema.Computer(
CPUCores,
HasLTE,
HasWifi,
Motherboard,
Price,
ReleaseDate,
VideoCard) 
";

string sql2Values = $"values ('{cmtr.CPUCores}', '{cmtr.HasLTE}', '{cmtr.HasWifi}', '{cmtr.Motherboard}', '{cmtr.Price}', '{cmtr.ReleaseDate.ToString("yyyy-MM-dd")}', '{cmtr.VideoCard}')";

string sql = $"{sql1} {sql2Values}";

System.Console.WriteLine(sql);

var result = dataContext.ExecuteSql(sql);

Console.WriteLine(result);

// "Computer." is not nessesary but is good practice
string sqlSelect = @"select
Computer.ReleaseDate,
Computer.VideoCard,
Computer.Motherboard,
Computer.Price
from TutorialAppSchema.Computer";

var compResult = dataContext.LoadData<Computer>(sqlSelect);

foreach(var item in compResult){
    System.Console.WriteLine($"{item.ComputerId} | {item.ReleaseDate} | {item.VideoCard} | {item.Motherboard} | {item.Price}");
}