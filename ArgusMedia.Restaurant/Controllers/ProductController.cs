using ArgusMedia.Restaurant.Dtos;
using ArgusMedia.Restaurant.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArgusMedia.Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        protected readonly IMapper Mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            Mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllProductsAsync()
        {        
            _logger.LogInformation("Get All Products");
            var products = await _productService.GetAllProductsAsync();
            var returnModel = Mapper.Map<IEnumerable<ProductReadDto>>(products);

            return new OkObjectResult(returnModel);
        }
    }
}
