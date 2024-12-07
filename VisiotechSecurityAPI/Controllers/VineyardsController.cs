using Microsoft.AspNetCore.Mvc;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VineyardsController : Controller
    {
        public readonly IVineyardService _vineyardService;

        public VineyardsController(IVineyardService vineyardService)
        {
            _vineyardService = vineyardService;
        }

        [HttpGet("managers")]
        public async Task<ActionResult<Dictionary<string, List<string>>>> GetManagers()
        {
            var VineyardManagers = await _vineyardService.GetVineyardManagersDiccionaryAsync();
            return Ok(VineyardManagers);
        }
    }
}
