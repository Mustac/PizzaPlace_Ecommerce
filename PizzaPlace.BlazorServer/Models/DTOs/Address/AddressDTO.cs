using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.BlazorServer.Models.DTOs.Address
{
    public class AddressDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 80, MinimumLength = 2)]
        public string Street { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 80, MinimumLength = 2)]
        public string City { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 80, MinimumLength = 2)]
        public string Zip { get; set; } = string.Empty;
    }
}
