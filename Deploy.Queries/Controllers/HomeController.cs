using Microsoft.AspNetCore.Mvc;

namespace Deploy.Commands.Queries
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("read")]
        public IActionResult Write()
        {
            return Ok("Successfully read.");
        }
    }
}
