
using Blazored.Toast;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PizzaPlace.BlazorServer;

public class ServicesRegistrator
{
    public static void Register(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options =>
        options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser, IdentityRole>(o =>
        {
            o.SignIn.RequireConfirmedEmail = false;
            o.SignIn.RequireConfirmedPhoneNumber = false;
            o.SignIn.RequireConfirmedAccount = false;
            o.Password.RequireDigit = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredUniqueChars = 0;
            o.Password.RequiredLength = 4;
            o.Password.RequireUppercase = false;
        })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();


        services.AddScoped<NavMenuService>();

        services.AddBlazoredToast();

        services.AddBlazoredLocalStorage();

        services.AddScoped<ShoppingCartService>();

        services.AddScoped<ProductService>();

        services.AddScoped<MyStorageService>();

    }
}
