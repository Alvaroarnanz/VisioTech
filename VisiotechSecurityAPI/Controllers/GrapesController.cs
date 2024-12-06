using Microsoft.AspNetCore.Mvc;
using VisiotechSecurityAPI.Domain.Interfaces;

namespace VisiotechSecurityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrapesController : Controller
    {
        public readonly IGrapeService _grapeService;

        public GrapesController(IGrapeService grapeService)
        {
            _grapeService = grapeService;
        }

        [HttpPost("area")]
        public async Task<ActionResult<Dictionary<string, int>>> GetGrapesArea()
        {
            var grapesArea = await _grapeService.GetAreaByGrapeAsync();
            return Ok(grapesArea);
        }
    }
}
