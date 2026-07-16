using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/listItem")]
    public class ListItemController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> TestController()
        {
            return Ok("Test");
        }
    }
}
