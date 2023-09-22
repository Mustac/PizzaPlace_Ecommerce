
using Blazored.Toast;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PizzaPlace.BlazorServer;

public class ServicesRegistrator
{
    public static void Register(IServiceCollection services)
    {
        services.AddScoped<NavMenuService>();

        services.AddBlazoredToast();

        services.AddBlazoredLocalStorage();

        services.AddScoped<ShoppingCartService>();

        services.AddScoped<ProductService>();

        services.AddScoped<MyStorageService>();

    }
}
