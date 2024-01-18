﻿using Microsoft.AspNetCore.Identity;

namespace PizzaPlace.BlazorServer.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<Address>? Addresses { get; set; }
    public ICollection<Order>? Orders { get; set; }
    public ICollection<Order>? DeliveryOrders { get; set; }
}
