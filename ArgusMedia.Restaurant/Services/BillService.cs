using ArgusMedia.Restaurant.Dtos;
using ArgusMedia.Restaurant.Models;

namespace ArgusMedia.Restaurant.Services
{
    public class BillService : IBillService
    {
        private readonly ILogger<BillService> _logger;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        /// <summary>
        /// These parameters can be moved to the DataBase as extended logic.
        /// </summary>
        private const int _discountFromHour = 19;
        private const int _discountPercent = 30;
        private const int _serviceCharge = 10;

        public BillService(IOrderService orderService, IProductService productService, ILogger<BillService> logger)
        {
            _logger = logger;
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<IEnumerable<BillReadDto>> CalculateBillAsync(IEnumerable<Guid> clientIds, bool isSplitBill)
        {
            IEnumerable<BillReadDto> result;
            var products = await _productService.GetAllProductsAsync();
            if (isSplitBill)
                result = await CalculateSplitBillAsync(clientIds, products);
            else
                result = await CalculateTotalBillAsync(clientIds, products);

            return result;
        }

        private async Task<IEnumerable<BillReadDto>> CalculateSplitBillAsync(IEnumerable<Guid> clientIds, IEnumerable<Product> products)
        {
            _logger.LogInformation("Calculate Split Bill");
            var result = new List<BillReadDto>();
            foreach (var clientId in clientIds)
            {
                var orders = await _orderService.GetOrdersAsync(clientId);
                var billDto = CalculateOrders(orders, products, clientId);
                result.Add(billDto);
            }

            return result;
        }

        private async Task<IEnumerable<BillReadDto>> CalculateTotalBillAsync(IEnumerable<Guid> clientIds, IEnumerable<Product> products)
        {
            _logger.LogInformation("Calculate Total Bill");
            var result = new List<BillReadDto>();
            var orders = await _orderService.GetOrdersAsync(clientIds);
            var billDto = CalculateOrders(orders, products, null);
            result.Add(billDto);

            return result;
        }

        private BillReadDto CalculateOrders(IEnumerable<Order> orders, IEnumerable<Product> products, Guid? clientId)
        {
            var orderDetails = new List<OrderDetailsReadDto>();
            var serviceCharge = 0m;
            var discountCharge = 0m;
            var drinkBill = 0m;
            var foodBill = 0m;
            var bill = 0m;
            foreach (var order in orders)
            {
                var product = products.Single(p => p.Id == order.ProductId);
                orderDetails.Add(new OrderDetailsReadDto
                {
                    Id = order.Id,
                    ProductName = product.Name,
                    ProductId = product.Id,
                    Price = product.Price,
                });

                bill += product.Price;
                if (product.IsDrink)
                {
                    drinkBill += product.Price;
                    if (order.CreatedDate.Hour >= _discountFromHour)
                    {
                        discountCharge += product.Price * _discountPercent / 100;
                    }
                }
                else
                {
                    serviceCharge += product.Price * _serviceCharge / 100;
                    foodBill += product.Price;
                }
            }

            var billDto = new BillReadDto
            {
                ClientId = clientId,
                Orders = orderDetails,
                ServiceChargePercent = serviceCharge != 0 ? _serviceCharge : 0,
                DiscountPercent = discountCharge != 0 ? _discountPercent : 0,
                Bill = bill,
                DrinkBill = drinkBill,
                FoodBill = foodBill,
                Discount = discountCharge,
                ServiceCharge = serviceCharge,
                TotalBill = bill + serviceCharge - discountCharge
            };
            return billDto; 
        }
    }
}
