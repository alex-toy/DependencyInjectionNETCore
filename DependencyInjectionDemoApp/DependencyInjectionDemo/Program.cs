using DependencyInjectionDemo;
using DependencyInjectionDemo.Logic;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddTransient<DemoLogic>(); // changes if I change page and then come back
//builder.Services.AddScoped<DemoLogic>(); // remains equal if I change page and then come back
//builder.Services.AddSingleton<DemoLogic>(); // remains equal even if i refresh

//builder.Services.AddScoped<IDemoLogic, DemoLogic>();
//builder.Services.AddTransient<IDemoLogic, BetterDemoLogic>();
builder.Services.AddTransient<IDemoLogic, DemoLogic>();

builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureHTTPRequestPipeline();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
