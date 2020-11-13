using Microsoft.AspNetCore.Mvc;

namespace Application.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Ok();
        }
    }
}
