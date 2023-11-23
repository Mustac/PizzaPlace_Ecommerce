
using Blazored.Toast;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PizzaPlace.BlazorServer.Helpers;

public class ServicesRegistrator
{
    public static async Task Register(IServiceCollection services, IConfiguration config)
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

        services.AddAutoMapper(typeof(Program));

        services.AddScoped<NavMenuService>();

        services.AddBlazoredToast();

        services.AddBlazoredLocalStorage();

        services.AddScoped<ShoppingCartService>();

        services.AddScoped<ProductService>();

        services.AddScoped<AccountService>();

        services.AddSingleton<GlobalService>();

        var userManager = services.BuildServiceProvider().GetRequiredService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
        var roleManager = services.BuildServiceProvider().GetRequiredService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;

        await DataSeeder.SeedUserAndRolesAsync(userManager, roleManager);

    }
}
