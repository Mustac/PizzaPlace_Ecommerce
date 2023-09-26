using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PizzaPlace.BlazorServer.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Chef", NormalizedName = "CHEF" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Delivery", NormalizedName = "DELIVERY" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Customer", NormalizedName = "CUSTOMER" }
                );
            base.OnModelCreating(builder);
        }


    }
}
