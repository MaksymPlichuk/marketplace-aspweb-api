using MarketPlace.API.Extensions;
using MarketPlace.API.Infrastracture;
using MarketPlace.BLL.Dtos.ItemCategory;
using MarketPlace.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryService _service;
        private string _basePath;
        private string _subPath;

        public CategoryController(CategoryService service, IWebHostEnvironment env)
        {
            _service = service;
            _basePath = Path.Combine(env.ContentRootPath, StaticFilesSettings.StoragePath);
            _subPath = StaticFilesSettings.CategoryPath;
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
        [HttpGet("by-name")]
        public async Task<IActionResult> GetByName([FromQuery]string name)
        {
            var resp = await _service.GetByNameAsync(name);
            return this.GetAction(resp);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm]CreateCategoryDto dto)
        {
            var res = await _service.CreateCategotyAsync(dto, _basePath, _subPath);
            return this.GetAction(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm]UpdateCategoryDto dto)
        {
            var res = await _service.UpdateCategotyAsync(dto, _basePath, _subPath);
            return this.GetAction(res);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var res = await _service.DeleteByIdAsync(id, _basePath);
            return this.GetAction(res);
        }
    }
}
