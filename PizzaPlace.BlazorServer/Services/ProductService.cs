using Microsoft.EntityFrameworkCore;
using PizzaPlace.BlazorServer.Models.DTOs;

namespace PizzaPlace.BlazorServer.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> NewProductAsync(ProductDTO productDto)
        {
            Product product = new Product(productDto.Name, productDto.Price, productDto.Ingredients);

            var prod = await _context.Products.AddAsync(product);

            var success = await _context.SaveChangesAsync() > 0;

            if (success)
                return prod.Entity;

            return null;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
            => await _context.Products.ToListAsync();

    }
}
