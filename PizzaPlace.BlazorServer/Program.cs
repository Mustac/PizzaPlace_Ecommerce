global using PizzaPlace.BlazorServer;
global using PizzaPlace.BlazorServer.Data;
global using PizzaPlace.BlazorServer.Services;
global using PizzaPlace.BlazorServer.Shared.Component;
global using PizzaPlace.Models;
global using Blazored.LocalStorage;


using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

ServicesRegistrator.Register(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
