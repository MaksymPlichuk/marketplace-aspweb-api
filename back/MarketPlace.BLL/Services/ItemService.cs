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
        private async Task<ItemEntity> GetItemWithDetailsByIdAsync(int id)
        {
            List<ItemEntity> items = _repository.GetAll().Include(i => i.Category)
                .Include(i => i.Reviews).ThenInclude(r => r.Author)
                .Include(i => i.Orders).ThenInclude(o => o.Seller)
                .Include(i => i.Orders).ThenInclude(o => o.Buyer)
                .Include(i => i.Seller).ToList();

            var entity = items.Where(i => i.Id == id).FirstOrDefault();
            if (entity != null)
            {
                return entity;
            }
            return null;
        }

        public async Task<ServiceResponse> CreateItemAsync(CreateItemDto dto, string basePath, string subPath)
        {
            ItemEntity entity = _mapper.CreateDtoToItemEntity(dto);
            if (dto.Image != null)
            {
                var res = await _imageService.CreateImageAsync(dto.Image, basePath, subPath);
                if (!res.IsSuccess) { return res; }

                entity.Image = res.Payload.ToString();
            }
            try
            {
                await _repository.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                if (entity.Image != null) { _imageService.DeleteImage(basePath, entity.Image); }
                return ServiceResponse.Failure(ex.Message);
            }
            return ServiceResponse.Success($"Оголошення {entity.Name} створено!", _mapper.ItemToItemDto(entity));//test

        }
        public async Task<ServiceResponse> UpdateItemAsync(UpdateItemDto dto, string basePath, string subPath)
        {
            //var entity = await _repository.GetByIdAsync(dto.Id);
            var entity = await GetItemWithDetailsByIdAsync(dto.Id);
            if (entity == null)
            {
                return ServiceResponse.Failure($"Оголошення з id [{dto.Id}] не існує!");
            }

            string oldName = entity.Name;
            _mapper.UpdateItem(dto, entity);

            bool upRes;
            if (dto.Image != null)
            {
                if (entity.Image != null) { _imageService.DeleteImage(basePath, entity.Image); }
                var resp = await _imageService.CreateImageAsync(dto.Image, basePath, subPath);
                if (!resp.IsSuccess) return resp;

                entity.Image = resp.Payload.ToString();
            }

            upRes = await _repository.UpdateAsync(entity);

            if (!upRes) return ServiceResponse.Failure("Невдалося зберегти");//подумати що в такому випадку з Image
            return ServiceResponse.Success($"Оголошення {oldName} успішно оновлено!", _mapper.ItemToItemDto(entity));
        }


        public async Task<ServiceResponse> RemoveItemAsync(int id, string basePath)
        {
            //var entity = await _repository.GetByIdAsync(id);
            var entity = await GetItemWithDetailsByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Failure($"Оголошення з id [{id}] не існує!");
            }
            if (entity.Image != null)
            {
                var resp = _imageService.DeleteImage(basePath, entity.Image);
                if (!resp.IsSuccess) return resp;
            }
            bool delResp = await _repository.DeleteAsync(id);
            if (!delResp) return ServiceResponse.Failure("Невдалося Видалити");

            return ServiceResponse.Success($"Оголошення [{entity.Name}] успішно видалено", _mapper.ItemToItemDto(entity));
        }

        public async Task<ServiceResponse> GetItemsByNameAsync(string name)
        {
            var entities = await _repository.FindItemsByNameAsync(name);
            if (entities == null) return ServiceResponse.Failure($"Незнайдено жодних збігів з {name}");

            var dtos = _mapper.ItemsToItemDtos(entities);
            return ServiceResponse.Success($"Знайдено {dtos.Count()} збігів з {name}", dtos);

        }

    }
}
