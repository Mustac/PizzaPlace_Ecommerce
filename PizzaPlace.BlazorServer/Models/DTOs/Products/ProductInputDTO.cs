using PizzaPlace.BlazorServer.Helpers;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.BlazorServer.Models.DTOs.Products
{
    public class ProductInputDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [FloatRange(minimum: 0, maximum: 999, ErrorMessage = "The price must be between 0 and 999")]
        public float Price { get; set; }

        [Required]
        [StringLength(maximumLength: 300, MinimumLength = 3)]
        public string Ingredients { get; set; } = string.Empty;

        [FloatRange(minimum: 0, maximum: 999, ErrorMessage = "The price must be between 0 and 999")]
        [LessThan("Price", ErrorMessage = "Discounted Price must be less than the regular Price")]
        public float? DiscountedPrice { get; set; }
        public bool IsActive { get; set; }

    }
}
