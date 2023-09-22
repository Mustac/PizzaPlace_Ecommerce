using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPlace.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Ingridients { get; set; } = string.Empty;
        public float Price { get; set; }
        public float DiscountedPrice { get; set; }
    }
}
