using Microsoft.AspNetCore.Mvc;

namespace BalAI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new { status = "ok", timestamp = System.DateTime.UtcNow });
    }
}
