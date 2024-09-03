using Microsoft.AspNetCore.Mvc;

namespace BlogHsn.NET.WORKERAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Worker API is running...");
        }
    }
}