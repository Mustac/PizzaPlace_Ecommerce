using PizzaPlace.BlazorServer.Services;
using PizzaPlace.BlazorServer.Shared.NavMenuComponent;

namespace PizzaPlace.BlazorServer
{
    public class ServicesRegistrator
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<GlobalService>();
        }
    }
}
