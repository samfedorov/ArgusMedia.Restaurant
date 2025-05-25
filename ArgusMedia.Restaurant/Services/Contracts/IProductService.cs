using ArgusMedia.Restaurant.Models;

namespace ArgusMedia.Restaurant.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
