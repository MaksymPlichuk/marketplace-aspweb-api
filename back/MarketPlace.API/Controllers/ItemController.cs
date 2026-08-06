using MarketPlace.API.Extensions;
using MarketPlace.API.Infrastracture;
using MarketPlace.BLL.Dtos.Item;
using MarketPlace.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketPlace.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private ItemService _service;
        private string _basePath;
        private string _subPath;
        public ItemController(ItemService service, IWebHostEnvironment env)
        {
            _service = service;
            _basePath = Path.Combine(env.ContentRootPath, StaticFilesSettings.StoragePath);
            _subPath = StaticFilesSettings.ItemPath;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var res = _service.GetAllItems();
            return this.GetAction(res);
        }
        [HttpGet("/id")]
        public async Task<IActionResult> GetItemById([FromQuery]int id)
        {
            var res = await _service.GetItemByIdAsync(id);
            return this.GetAction(res);
        }
        [HttpGet("/name")]
        public async Task<IActionResult> GetByName([FromQuery]string name)
        {
            var res = await _service.GetItemsByNameAsync(name);
            return this.GetAction(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromForm]CreateItemDto dto)
        {
            var res = await _service.CreateItemAsync(dto, _basePath, _subPath);
            return this.GetAction(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem([FromForm] UpdateItemDto dto)
        {
            var res = await _service.UpdateItemAsync(dto, _basePath, _subPath);
            return this.GetAction(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var res = await _service.RemoveItemAsync(id, _basePath);
            return this.GetAction(res);
        }

    }
}
