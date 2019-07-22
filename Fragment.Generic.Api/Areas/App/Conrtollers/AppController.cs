using Microsoft.AspNetCore.Mvc;

namespace Fragment.Generic.Api.Areas.App.Conrtollers
{
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new {Name = "Mantle"});
        }
    }
}
