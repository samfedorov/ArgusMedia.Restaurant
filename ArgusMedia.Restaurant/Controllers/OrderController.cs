using ArgusMedia.Restaurant.Dtos;
using ArgusMedia.Restaurant.Models;
using ArgusMedia.Restaurant.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgusMedia.Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly IMapper Mapper;

        public OrderController(IMapper mapper, IOrderService orderService, ILogger<OrderController> logger)
        {
            _logger = logger;
            Mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderReadDto>>> MakeOrderAsync([FromBody] List<OrderCreateDto> ordersCreateDto)
        {
            _logger.LogInformation("Create new order");
            var ordersModel = Mapper.Map<IEnumerable<Order>>(ordersCreateDto);
            await _orderService.CreateOrdersAsync(ordersModel);
            var returnModel = Mapper.Map<IEnumerable<OrderReadDto>>(ordersModel);
            return Ok(returnModel);
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrderAsync(Guid orderId)
        {
            _logger.LogInformation("Delete order");
            var order = await _orderService.GetOrderAsync(orderId);
            if (order == null)
                return NotFound();

            await _orderService.DeleteOrderAsync(order);
            return NoContent();
        }
    }
}