using ArgusMedia.Restaurant.Models;

namespace ArgusMedia.Restaurant.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrderAsync(Guid orderId);
        
        Task<IEnumerable<Order>> GetOrdersAsync(Guid clientId);
        
        Task<IEnumerable<Order>> GetOrdersAsync(IEnumerable<Guid> clientIds);

        Task CreateOrdersAsync(IEnumerable<Order> orders);

        Task DeleteOrderAsync(Order order);
    }
}
