using ArgusMedia.Restaurant.Models;

namespace ArgusMedia.Restaurant.Repositories
{
    public class ProductRepository : BaseRepository<Product, ProductRepository>, IProductRepository
    {
        public ProductRepository(RestaurantDbContex context, ILogger<ProductRepository> logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            Logger.LogInformation($"Get all Products");
            var result = await GetAllAsync();

            return result;
        }
    }
}
