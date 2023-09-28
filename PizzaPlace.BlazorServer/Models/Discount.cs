namespace PizzaPlace.BlazorServer.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Percentage { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
