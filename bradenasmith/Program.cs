using bradenasmith;
using bradenasmith.Interfaces;
using bradenasmith.Models;
using bradenasmith.Services;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using bradenasmith.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IGitHubApiService, GitHubApiService>();

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs", rollingInterval: RollingInterval.Day)
            .CreateLogger();

builder.Services.AddDbContext<bradenasmithContext>(
    options =>
        options
            .UseNpgsql(
                builder.Configuration["bradenasmith_DBCONNECTIONSTRING"]
                    ?? throw new InvalidOperationException(
                        "Connection string 'bradenasmithShowcase' not found."
                    )
            )
            .UseSnakeCaseNamingConvention()
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
