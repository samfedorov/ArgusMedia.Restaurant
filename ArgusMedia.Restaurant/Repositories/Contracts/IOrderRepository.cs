using ArgusMedia.Restaurant.Models;

namespace ArgusMedia.Restaurant.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderAsync(Guid orderId);
        
        Task<IEnumerable<Order>> GetOrdersAsync(Guid clientId);

        Task CreateOrdersAsync(IEnumerable<Order> orders);

        Task DeleteOrderAsync(Order order);
    }
}
