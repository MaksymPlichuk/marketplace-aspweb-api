using MarketPlace.API.Extensions;
using MarketPlace.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllUsersAsync();
            return this.GetAction(res);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var resp = await _service.GetUserByIdAsync(id);
            return this.GetAction(resp);
        }
    }
}
