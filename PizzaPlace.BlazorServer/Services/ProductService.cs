using Microsoft.EntityFrameworkCore;
using PizzaPlace.BlazorServer.Helpers;
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

        public async Task<string> UpdateProductAsync(ProductDTO productDto)
        {
            var product = await _context.Products.FindAsync(productDto.Id);

            if (product is null)
                return State.NotFound;

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.DiscountedPrice = productDto.DiscountedPrice.HasValue? productDto.DiscountedPrice.Value:0;
            product.Ingredients = productDto.Ingredients;

            _context.Update(product);

            return await _context.SaveChangesAsync() > 0 ? State.Success : State.Fail;


        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
            => await _context.Products.Where(x=>!x.IsDeleted).ToListAsync();

        public async Task<bool> SoftDeleteAsync(int Id)
        {
            var product = await _context.Products.FindAsync(Id);

            if (product is null) return false;

            product.IsDeleted = true;

            _context.Products.Update(product);

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
