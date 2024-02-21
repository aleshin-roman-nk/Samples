using System.Text.Json;
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

var computers = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);
/* 
if (computers != null)
{
    foreach (var comp in computers)
    {
        System.Console.WriteLine(comp.Motherboard);
    }
} 
*/

if (computers != null)
{
    foreach (var comp in computers)
    {
        string sql = @"INSERT INTO mycourse.computers(
    Motherboard,
    CPUCores,
    HasWifi,
    HasLTE,
    ReleaseDate,
    Price,
    VideoCard
) VALUES ('" + escapeSingleQuote(comp.Motherboard)
        + "','" + comp.CPUCores
        + "','" + Convert.ToInt16(comp.HasWifi)
        + "','" + Convert.ToInt16(comp.HasLTE)
        + "','" + comp.ReleaseDate == null ? "NULL" : comp.ReleaseDate?.ToString("yyyy-MM-dd")
        + "','" + comp.Price
        + "','" + escapeSingleQuote(comp.VideoCard)
        + "')";

System.Console.WriteLine(sql);

        dapper.ExecuteSql(sql);
    }
}

string escapeSingleQuote(string inputString)
{
    string outputString = inputString.Replace("'", "''");
    return outputString;
}