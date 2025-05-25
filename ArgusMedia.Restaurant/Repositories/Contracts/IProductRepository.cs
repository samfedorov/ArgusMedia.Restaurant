using ArgusMedia.Restaurant.Models;

namespace ArgusMedia.Restaurant.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
