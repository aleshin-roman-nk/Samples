using System.Text.Json;
using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using MyCourse.Data;
using Newtonsoft.Json;


IConfiguration config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

//var dataContext = new DbContextEFMySQL(config);
var dapper = new DataContextDapperMySQL(config);


/* dataContext.Add(cmtr);
dataContext.SaveChanges();

var compResult = dataContext.Computers.ToArray();

foreach(var item in compResult){
    System.Console.WriteLine($"{item.ComputerId} | {item.ReleaseDate} | {item.VideoCard} | {item.Motherboard} | {item.Price}");
} */

//using StreamWriter openFile = new ("log.txt", append: true);

var computersJson = File.ReadAllText("computers.json");

//var computersSnakeJson = File.ReadAllText("computerssnake.json");

//Mapper mapper = new Mapper();

var computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

if (computers != null)
{
    foreach (var comp in computers)
    {
        string sql = @"INSERT INTO mycourse.Computers (
                        Motherboard,
                        CPUCores,
                        HasWifi,
                        HasLTE,
                        ReleaseDate,
                        Price,
                        VideoCard
                    ) VALUES (
                        @Motherboard,
                        @CPUCores,
                        @HasWifi,
                        @HasLTE,
                        @ReleaseDate,
                        @Price,
                        @VideoCard
                    );";

        dapper.ExecuteSqlWithParameters(sql, new
    {
        Motherboard = comp.Motherboard,
        CPUCores = comp.CPUCores,
        HasWifi = comp.HasWifi,
        HasLTE = comp.HasLTE,
        ReleaseDate = comp.ReleaseDate,
        Price = comp.Price,
        VideoCard = comp.VideoCard
    });
    }
}