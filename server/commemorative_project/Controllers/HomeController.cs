using Microsoft.AspNetCore.Mvc;

namespace commemorative_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController:ControllerBase
    {
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Get()
        {
            _logger.LogInformation("message from get method");
            return Ok("Wellcome");
        }
    }
}
