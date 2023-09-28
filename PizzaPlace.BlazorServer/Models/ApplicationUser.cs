using Microsoft.AspNetCore.Identity;

namespace PizzaPlace.BlazorServer.Models;

public class ApplicationUser : IdentityUser
{
    public string AddressStreet { get; set; }
    public string AddressCity { get; set; }
    public string AddressState { get; set; }
    public string AddressZip { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Order> ChefOrders { get; set; }
    public ICollection<Order> DeliveryOrders { get; set; }
}
