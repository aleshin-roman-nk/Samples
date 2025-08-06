using EFCoreRepo;
using Microsoft.EntityFrameworkCore;
using ServicesCore;
using ServicesCore.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AnimalService>();
builder.Services.AddScoped<IAnimalRepo, AnimalRepo>();
builder.Services.AddDbContext<AppData>(options =>
	options.UseSqlite("Data Source=sandbox.sqlite"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
