using Microsoft.EntityFrameworkCore;

namespace ArgusMedia.Restaurant.Models
{
    public class RestaurantDbContex : DbContext
    {
        public RestaurantDbContex(DbContextOptions<RestaurantDbContex> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedProducts(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        private void SeedProducts(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Product>().HasData(new ProductsSeedData().ProductsData);
    }
}
