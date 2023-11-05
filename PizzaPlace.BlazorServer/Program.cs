global using Blazored.LocalStorage;
global using Blazored.Toast.Services;
global using Microsoft.JSInterop;
global using Newtonsoft.Json;
global using PizzaPlace.BlazorServer.Data;
global using PizzaPlace.BlazorServer.Helpers;
global using PizzaPlace.BlazorServer.Helpers.Enums;
global using PizzaPlace.BlazorServer.Models;
global using PizzaPlace.BlazorServer.Services;
global using PizzaPlace.BlazorServer.Services.BaseServices;
global using PizzaPlace.BlazorServer.Shared.Component.ConfirmationModalPackage;
global using PizzaPlace.Models.DTOs.Products;
global using System.Collections.Generic;
global using System.Linq;
global using System.Threading.Tasks;
global using PizzaPlace.GlobalServices;
global using AutoMapper;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

BaseService.ConnString = builder.Configuration.GetConnectionString("DefaultConnection");
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
