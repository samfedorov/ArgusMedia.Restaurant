using ArgusMedia.Restaurant.Dtos;
using ArgusMedia.Restaurant.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArgusMedia.Restaurant.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private readonly IBillService _billService;

        public BillController(IBillService billService, ILogger<BillController> logger)
        {
            _logger = logger;
            _billService = billService;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<BillReadDto>>> BillAsync([FromBody] BillDto parameters)
        {
            _logger.LogInformation("Get bill");
            var result = await _billService.CalculateBillAsync(parameters.ClientIds, parameters.IsSplit);

            return Ok(result);
        }
    }
}
