namespace PizzaPlace.BlazorServer.Models;

public class Product
{
    public Product(){}
    public Product(string name, float price, string ingredients)
    {
        Name = name;
        Price = price;
        Ingredients = ingredients;
    }

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; }
    public float DiscountedPrice { get; set; }
    public string Ingredients { get; set; }
    public bool IsArchived { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; set; }
}
