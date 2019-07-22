using Microsoft.AspNetCore.Mvc;

namespace Fragment.Generic.Api.Areas.User.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
