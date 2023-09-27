using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPlace.BlazorServer.Models;

public class ApplicationUser : IdentityUser
{
    public string AddressStreet { get; set; }
    public string AddressCity { get; set; }
    public string AddressState { get; set; }
    public string AddressZip { get; set; }
    public List<Order> Orders { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int? DiscountId { get; set; }
    public Discount Discount { get; set; }
    public ICollection<ProductIngredient> ProductIngredients { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<ProductIngredient> ProductIngredients { get; set; }
}

public class ProductIngredient
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public DateTime TimeOrdered { get; set; }
    public DateTime? TimeCompleted { get; set; }
    public DateTime? TimeDelivered { get; set; }
    public float TotalPrice { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string Status { get; set; }
    public string ChefId { get; set; }
    public ApplicationUser Chef { get; set; }
    public string DeliveryId { get; set; }
    public ApplicationUser Delivery { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}

public class OrderProduct
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}

public class Feedback
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public string Comment { get; set; }
    public int Rating { get; set; }
}

public class Discount
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Percentage { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
