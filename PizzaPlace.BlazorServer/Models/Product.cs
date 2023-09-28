namespace PizzaPlace.BlazorServer.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public int DiscountId { get; set; }
    public Discount Discount { get; set; }
    public ICollection<ProductIngredient> ProductIngredients { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
