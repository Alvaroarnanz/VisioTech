using Microsoft.AspNetCore.Mvc;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagersController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagersController(IManagerService managersService)
        {
            _managerService = managersService;
        }

        [HttpGet("ids")]
        public async Task<ActionResult<List<int>>> GetManagerIds()
        {
            var managerIds = await _managerService.GetManagerIdsAsync();
            return Ok(managerIds);
        }

        [HttpGet("taxnumbers")]
        public async Task<ActionResult<List<string>>> GetTaxNumbers([FromQuery] bool sorted)
        {
            var managerIds = await _managerService.GetTaxNumbersAsync(sorted);
            return Ok(managerIds);
        }

        [HttpPost("totalarea")]
        public async Task<ActionResult<Dictionary<string, int>>> GetTotalAreas()
        {
            var managerTotalArea = await _managerService.GetManagerTotalAreaAsync();
            return Ok(managerTotalArea);
        }
    }
}
