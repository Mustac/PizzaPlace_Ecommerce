using Microsoft.AspNetCore.Identity;

namespace PizzaPlace.BlazorServer.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Address>? Addresses { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Order>? ChefOrders { get; set; }
    public ICollection<Order>? DeliveryOrders { get; set; }
}
