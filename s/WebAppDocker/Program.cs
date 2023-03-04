var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Enter command");
app.MapGet("/{cmd}", (string cmd) => $"recieved command :{cmd}");

app.Run();
