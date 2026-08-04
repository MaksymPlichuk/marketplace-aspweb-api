using MarketPlace.API.Extensions;
using MarketPlace.API.Infrastracture;
using MarketPlace.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryService _service;
        private string _path;

        public CategoryController(CategoryService service, IWebHostEnvironment env)
        {
            _service = service;
            _path = Path.Combine(env.ContentRootPath, StaticFilesSettings.StoragePath, StaticFilesSettings.CategoryPath);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAllAsync();
            return this.GetAction(res);
        }
        [HttpGet("by-id")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            var res = await _service.GetByIdAsync(id);
            return this.GetAction(res);
        }

    }
}
