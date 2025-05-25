using ArgusMedia.Restaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace ArgusMedia.Restaurant.Repositories
{
    public class OrderRepository : BaseRepository<Order, OrderRepository>, IOrderRepository
    {
        public OrderRepository(RestaurantDbContex context, ILogger<OrderRepository> logger) : base(context, logger)
        {
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            Logger.LogInformation($"Get Order by id: {orderId}");
            var result = await Entities.SingleOrDefaultAsync<Order>(s => s.Id == orderId);
            return result;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(Guid clientId)
        {
            Logger.LogInformation($"Get Order by ClientId: {clientId}");
            var result = await Entities.Where(s => s.ClientId == clientId).ToListAsync();
            return result;
        }

        public async Task CreateOrdersAsync(IEnumerable<Order> orders)
        {
            Logger.LogInformation("Create new Order");
            await AddRangeAsync(orders);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            Logger.LogInformation($"Delete order with id: {order.Id}");
            await DeleteAsync(order);
        }
    }
}
