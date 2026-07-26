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
        private string _path;
        public ItemController(ItemService service, IWebHostEnvironment env)
        {
            _service = service;
            _path = Path.Combine(env.ContentRootPath, StaticFilesSettings.StoragePath, StaticFilesSettings.ItemPath);
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var res = _service.GetAllItems();
            return this.GetAction(res);
        }
        [HttpGet("/id/")]
        public async Task<IActionResult> GetItemById([FromRoute]int id)
        {
            var res = await _service.GetItemByIdAsync(id);
            return this.GetAction(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromForm]CreateItemDto dto)
        {
            var res = await _service.AddItemAsync(dto, _path);//перейменувати у Dto додати Id 
            return this.GetAction(res);
        }
        //[HttpPut]
        //public IActionResult(UpdateItem([FromForm]UpdateItemDto dto)
        //{

        //}

    }
}
