global using Blazored.LocalStorage;
global using Blazored.Toast.Services;
global using Microsoft.JSInterop;
global using Newtonsoft.Json;
global using PizzaPlace.BlazorServer.Data;
global using PizzaPlace.BlazorServer.Helpers;
global using PizzaPlace.BlazorServer.Helpers.Enums;
global using PizzaPlace.BlazorServer.Models;
global using PizzaPlace.BlazorServer.Models.DTOs.Products;
global using PizzaPlace.BlazorServer.Services;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using PizzaPlace.BlazorServer.Shared.Component.ConfirmationModalPackage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

ServicesRegistrator.Register(builder.Services, builder.Configuration);
builder.Services.AddScoped<ConfirmationModal>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
