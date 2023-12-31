﻿using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Models.DTOs.Products;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ingredients { get; set; } = string.Empty;
    public float Price { get; set; }
    public float DiscountedPrice { get; set; }
    public bool IsHovering { get; set; }
    public int Amount { get; set; }
    public bool ProductNeedsDeletion { get; set; }
    public bool IsArchived { get; set; }
}

public class ProductOrderDTO
{
    public string? UserId { get; set; }
    public bool CanUserOrder { get; set; } = true;
    public float TotalPrice { get; set; }
    public float DiscountedPrice { get; set; }
    public AddressDTO? Address { get; set; }
    public List<ProductDTO>? Products { get; set;}
}


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

    [LessThan("Price", ErrorMessage ="Has to be less than price")]
    public float? DiscountedPrice { get; set; }
}
