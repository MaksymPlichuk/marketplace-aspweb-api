using MarketPlace.DAL.Repositories;
using MarketPlace.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using MarketPlace.BLL.Dtos.Item;
using MarketPlace.DAL.Entities;
using MarketPlace.BLL.Mapperly;
using Microsoft.EntityFrameworkCore;
using MarketPlace.DAL;

namespace MarketPlace.BLL.Services
{
    public class ItemService
    {
        private readonly MapperProfile _mapper;
        private ItemRepository _repository;
        private ImageService _imageService;
        public ItemService(ItemRepository repository, MapperProfile mapper, ImageService imageService)
        {
            _repository = repository;
            _mapper = mapper;
            _imageService = imageService;
        }

        public ServiceResponse GetAllItems()
        {
            List<ItemEntity> items = _repository.GetAll().Include(i => i.Category)
                .Include(i => i.Reviews).ThenInclude(r => r.Author) //підгружає окремо до кожного dto user, інакше буде null
                .Include(i => i.Orders).ThenInclude(o => o.Seller)
                .Include(i => i.Orders).ThenInclude(o => o.Buyer)
                .Include(i => i.Seller).ToList();

            List<ItemDto> itemsDto = new List<ItemDto>();

            if (items != null)
            {
                itemsDto = _mapper.ItemsToItemDtos(items);
                return ServiceResponse.Success($"Дістано {itemsDto.Count()} Оголошень", itemsDto);
            }
            return ServiceResponse.Failure($"Немає оголошень");
        }
        public async Task<ServiceResponse> GetItemByIdAsync(int id)
        {
            //var entity = await _repository.GetByIdAsync(id); Переробити Include

            List<ItemEntity> items = _repository.GetAll().Include(i => i.Category)
                .Include(i => i.Reviews).ThenInclude(r => r.Author) //підгружає окремо до кожного dto user, інакше буде null
                .Include(i => i.Orders).ThenInclude(o => o.Seller)
                .Include(i => i.Orders).ThenInclude(o => o.Buyer)
                .Include(i => i.Seller).ToList();

            var entity = items.Where(i => i.Id == id).FirstOrDefault();

            if (entity != null)
            {
                ItemDto dto = _mapper.ItemToItemDto(entity);
                return ServiceResponse.Success($"Оголошення з id: {id} знайдено!", dto);
            }
            return ServiceResponse.Failure($"Оголошення з id: {id} не існує!");
        }

        public async Task<ServiceResponse> AddItemAsync(CreateItemDto dto, string storagePath)
        {
            ItemEntity entity = _mapper.CreateDtoToItemEntity(dto);
            if (dto.Image != null)
            {
                var res = await _imageService.CreateImageAsync(dto.Image, storagePath);
                if (!res.IsSuccess) { return res; }

                entity.Image = res.Payload.ToString();
                //todo save
                return ServiceResponse.Success("Created", entity);

            }
            return ServiceResponse.Success("Created", entity);

        }
        public ServiceResponse RemoveItem()
        {
            return null;//todo
        }

        public async Task<ServiceResponse> GetItemsByName()
        {
            return null;//подумати над Include як обійти
        }
        public async Task<ServiceResponse> UpdateItemAsync(ItemDto item)
        {
            return null;
        }

    }
}
