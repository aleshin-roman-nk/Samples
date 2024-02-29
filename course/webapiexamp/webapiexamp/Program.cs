using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using webapiexamp.data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DbContextMySql>();
builder.Services.AddScoped<ComputersRepo>();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: "AllowAll",
		builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		});
}); // добавляем сервисы CORS

builder.Services.AddDbContext<DbContextMySql>(options =>
{
	var dbIp = builder.Configuration["DB_IP"] != null ? builder.Configuration["DB_IP"] : "localhost";
	var dbPort = builder.Configuration["DB_PORT"] != null ? builder.Configuration["DB_PORT"] : "3306";

	var connection = $"Server={dbIp};Database=mycourse;port={dbPort};user=root;password=1111;";

	//options.UseMySql(builder.Configuration.GetConnectionString("RemoteMySqlConnection"), new MySqlServerVersion(new Version(8, 0, 25)));
	options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25)));
	
	
	
	
	//options.LogTo(Console.WriteLine);
	//options.EnableSensitiveDataLogging(true);
	//options.UseLoggerFactory(null);
});

var app = builder.Build();

// настраиваем CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
	errorApp.Run(async context =>
	{
		context.Response.StatusCode = StatusCodes.Status500InternalServerError;
		//context.Response.ContentType = "application/problem+json";
		context.Response.ContentType = "text/plain";

		var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

		if (exceptionHandlerPathFeature?.Error != null)
		{
			var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

			// Log only the exception message
			//logger.LogError(exceptionHandlerPathFeature.Error.Message);

			//var problemDetails = new ProblemDetails
			//{
			//	Status = StatusCodes.Status500InternalServerError,
			//	Title = "An error occurred while processing your request.",
			//	Detail = exceptionHandlerPathFeature.Error.Message // Or a generic error message
			//};

			//var json = System.Text.Json.JsonSerializer.Serialize(problemDetails);
			//await context.Response.WriteAsync(json);
			await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.Message);
		}
	});
});


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
