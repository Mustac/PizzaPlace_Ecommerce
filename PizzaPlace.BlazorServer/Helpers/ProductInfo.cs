
namespace PizzaPlace.BlazorServer.Helpers
{
    public class ProductInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ingredients { get; set; } = string.Empty;
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
        public bool IsHovering { get; set; }
        public int Amount { get; set; }
    }

}
