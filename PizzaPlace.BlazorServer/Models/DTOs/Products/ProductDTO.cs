namespace PizzaPlace.BlazorServer.Models.DTOs.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
        public string Ingredients { get; set; } = string.Empty;
        public bool IsArchived { get; set; }
    }
}
