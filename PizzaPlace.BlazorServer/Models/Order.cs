using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaPlace.BlazorServer.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime TimeOrdered { get; set; }
    public DateTime? TimeCompleted { get; set; }
    public DateTime? TimeDelivered { get; set; }
    public float TotalPrice { get; set; }
    public float DiscountedPrice { get; set; }
    public string Status { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    [ForeignKey("Chef")]
    public string ChefId { get; set; }
    public ApplicationUser Chef { get; set; }

    [ForeignKey("Delivery")]
    public string DeliveryId { get; set; }
    public ApplicationUser Delivery { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
