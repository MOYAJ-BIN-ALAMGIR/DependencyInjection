using DependencyInjection.Models;
using System.Runtime.InteropServices;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("mysettings.json",
        optional: false,//file is not optimal)
        reloadOnChange: true);
});
builder.Services.Configure<MyJson>(builder.Configuration);
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<IStorage , Storage>();
builder.Services.AddTransient<ProductSum>();
// Add services to the container.

IWebHostEnvironment env = builder.Environment;

builder.Services.AddTransient<IRepository>(provider =>
{
    if (env.IsDevelopment())
    {
        var x = provider.GetService<Repository>();
        return x;
    }
    else
    {
        return new ProductionRepository();
    }
});
builder.Services.AddTransient<Repository>();

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
