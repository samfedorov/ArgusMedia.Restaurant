using ArgusMedia.Restaurant.Models;
using ArgusMedia.Restaurant.Repositories;

namespace ArgusMedia.Restaurant.Services
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            return await _orderRepository.GetOrderAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(Guid clientId)
        {
            return await _orderRepository.GetOrdersAsync(clientId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(IEnumerable<Guid> clientIds)
        {
            var orders = new List<Order>();
            foreach (var clientId in clientIds)
            {
                orders.AddRange(await _orderRepository.GetOrdersAsync(clientId));
            }
            return orders;
        }

        public async Task CreateOrdersAsync(IEnumerable<Order> orders)
        {
            await _orderRepository.CreateOrdersAsync(orders);
        }

        public async Task DeleteOrderAsync(Order order)
        {
            await _orderRepository.DeleteOrderAsync(order);
        }
    }
}
