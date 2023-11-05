using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace PizzaPlace.BlazorServer.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var activeProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Margherita", Price = 10, Ingredients = "Tomato, Mozzarella, Basil" },
                new Product { Id = 2, Name = "Pepperoni", Price = 12, Ingredients = "Tomato, Mozzarella, Pepperoni" },
                new Product { Id = 3, Name = "Hawaiian", Price = 13, Ingredients = "Tomato, Mozzarella, Ham, Pineapple" },
                new Product { Id = 4, Name = "BBQ Chicken", Price = 14, Ingredients = "BBQ Sauce, Mozzarella, Chicken, Red Onion" },
                new Product { Id = 5, Name = "Meat Lover", Price = 15, Ingredients = "Tomato, Mozzarella, Pepperoni, Ham, Bacon, Sausage" },
                new Product { Id = 6, Name = "Veggie", Price = 13, Ingredients = "Tomato, Mozzarella, Bell Pepper, Onion, Mushroom, Olives" },
                new Product { Id = 7, Name = "Mushroom", Price = 12, Ingredients = "Tomato, Mozzarella, Mushroom" },
                new Product { Id = 8, Name = "Four Cheese", Price = 14, Ingredients = "Tomato, Mozzarella, Cheddar, Feta, Parmesan" },
                new Product { Id = 9, Name = "Buffalo Chicken", Price = 14, Ingredients = "Buffalo Sauce, Mozzarella, Chicken, Celery" },
                new Product { Id = 10, Name = "Supreme", Price = 16, Ingredients = "Tomato, Mozzarella, Pepperoni, Bell Pepper, Onion, Mushroom, Olives, Sausage" },
                new Product { Id = 11, Name = "Chicken Alfredo", Price = 14, Ingredients = "Alfredo Sauce, Mozzarella, Chicken" },
                new Product { Id = 12, Name = "White Pizza", Price = 13, Ingredients = "Olive Oil, Mozzarella, Tomato, Basil" },
                new Product { Id = 13, Name = "Shrimp Scampi", Price = 16, Ingredients = "Olive Oil, Mozzarella, Shrimp, Garlic" },
                new Product { Id = 14, Name = "Philly Cheesesteak", Price = 15, Ingredients = "Tomato, Mozzarella, Steak, Bell Pepper, Onion" },
                new Product { Id = 15, Name = "Taco Pizza", Price = 14, Ingredients = "Tomato, Mozzarella, Ground Beef, Tomato, Lettuce, Cheddar" },
                new Product { Id = 16, Name = "Sausage", Price = 12, Ingredients = "Tomato, Mozzarella, Sausage" },
                new Product { Id = 17, Name = "Garlic Chicken", Price = 14, Ingredients = "Tomato, Mozzarella, Chicken, Garlic" },
                new Product { Id = 18, Name = "Spinach and Feta", Price = 13, Ingredients = "Tomato, Mozzarella, Spinach, Feta" },
                new Product { Id = 19, Name = "Pesto Veggie", Price = 14, Ingredients = "Pesto Sauce, Mozzarella, Bell Pepper, Onion, Mushroom, Olives" },
                new Product { Id = 20, Name = "Bacon Ranch", Price = 14, Ingredients = "Ranch Sauce, Mozzarella, Bacon, Chicken" },
            };

            builder.Entity<Product>().HasData(activeProducts);

            builder.Entity<ApplicationUser>()
            .HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .IsRequired();

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.ChefOrders)
                .WithOne(o => o.Chef)
                .HasForeignKey(o => o.ChefId);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.DeliveryOrders)
                .WithOne(o => o.Delivery)
                .HasForeignKey(o => o.DeliveryId);

            builder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

        }
    }
}
