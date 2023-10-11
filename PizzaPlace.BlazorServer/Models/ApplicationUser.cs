using Microsoft.AspNetCore.Identity;

namespace PizzaPlace.BlazorServer.Models;

public class ApplicationUser : IdentityUser
{
    public string AddressStreet { get; set; } = string.Empty;
    public string AddressCity { get; set; } = string.Empty;
    public string AddressState { get; set; } = string.Empty;
    public string AddressZip { get; set; } = string.Empty;
    public ICollection<Order> Orders { get; set; }
    public ICollection<Order> ChefOrders { get; set; }
    public ICollection<Order> DeliveryOrders { get; set; }
}
