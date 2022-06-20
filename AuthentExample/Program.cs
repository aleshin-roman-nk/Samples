using AuthentExample;
using AuthentExample.Model;
using AuthentExample.Service;
using AuthentExample.Service.Repos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//string connection = Microsoft.Extensions.Configuration.GetConnectionString("DefaultConnection");
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<UserContext>(opt => opt.UseSqlite(connection));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserOrdersRepo, UserOrdersRepo>();



builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
    options.AppendTrailingSlash = true;
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication("lngCollectorAppCookie")
    .AddCookie("lngCollectorAppCookie", options =>
    {
        options.Cookie.Name = "lngCollectorAppCookie";
        options.LoginPath = new PathString("/users/Login");
    });

builder.Services.AddScoped<IUserInfo>(provider =>
{
    var context = provider.GetService<IHttpContextAccessor>();
    return new UserInfo
    {
        UID = int.Parse(context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
