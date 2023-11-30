using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlace.BlazorServer.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime TimeOrdered { get; set; }
    public DateTime? TimeProduced { get; set; }
    public DateTime? TimeDelivered { get; set; }
    public float TotalPrice { get; set; }
    public float DiscountedPrice { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string FullAddress { get; set; } = string.Empty;

    [ForeignKey("User")]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    [ForeignKey("Chef")]
    public string? ChefId { get; set; }
    public ApplicationUser? Chef { get; set; }

    [ForeignKey("Delivery")]
    public string? DeliveryId { get; set; }
    public ApplicationUser? Delivery { get; set; }
    public ICollection<OrderProduct>? OrderProducts { get; set; }
}
