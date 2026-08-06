using MarketPlace.BLL.Dtos.ItemCategory;
using MarketPlace.BLL.Mapperly;
using MarketPlace.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Services
{
    public class CategoryService
    {
        private readonly MapperProfile _mapper;
        private ItemCategoryRepository _repository;
        private ImageService _imageService;

        public CategoryService(MapperProfile mapper, ItemCategoryRepository repository, ImageService imageService)
        {
            _mapper = mapper;
            _repository = repository;
            _imageService = imageService;
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _repository.GetAll().Include(c => c.Items).ToListAsync();
            if (entities == null) return ServiceResponse.Failure("Незнайдено категорій");

            return ServiceResponse.Success($"Знайдено {entities.Count()} категорій", _mapper.CatListToListDto(entities));

        }
        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return ServiceResponse.Failure($"Категорію з id[{id}] не знайдено");

            return ServiceResponse.Success($"Категорію з id[{id}] знайдено", _mapper.CatToDto(e));
        }
        public async Task<ServiceResponse> GetByNameAsync(string name)
        {
            var entities = await _repository.GetByNameAsync(name);
            if (entities == null || entities.Count == 0) return ServiceResponse.Failure($"Категорію {name} не знадено!");

            return ServiceResponse.Success($"Категорію {name} знадено", _mapper.CatListToListDto(entities));
        }

        public async Task<ServiceResponse> DeleteByIdAsync(int id, string basePath)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return ServiceResponse.Failure($"Категорію з id[{id}] не знайдено");

            if (entity.Image != null) { _imageService.DeleteImage(basePath, entity.Image); }
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                return ServiceResponse.Failure(ex.Message);
            }
            return ServiceResponse.Success($"Категорію '{entity.Name}' видалено", _mapper.CatToDto(entity));
        }

        public async Task<ServiceResponse> CreateCategotyAsync(CreateCategoryDto dto, string basePath, string subPath)
        {
            var entity = _mapper.CreateCatToEntity(dto);
            if (dto.Image != null)
            {
                var resp = await _imageService.CreateImageAsync(dto.Image, basePath, subPath);
                if (!resp.IsSuccess) return resp;

                entity.Image = resp.Payload.ToString();
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

            return ServiceResponse.Success($"Категорію {dto.Name} створено!", _mapper.CatToDto(entity));
        }
        public async Task<ServiceResponse> UpdateCategotyAsync(UpdateCategoryDto dto, string basePath, string subPath)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return ServiceResponse.Failure($"Категорії з {dto.Id} не існує");

            string oldName = entity.Name;
            string newImageName = "";

            _mapper.UpdateCatToEntity(dto, entity);

            if (dto.Image != null)
            {
                if (entity.Image != null) { _imageService.DeleteImage(basePath, entity.Image); }

                var resp = await _imageService.CreateImageAsync(dto.Image, basePath, subPath);
                if (!resp.IsSuccess) return resp;

                newImageName = resp.Payload.ToString();
                entity.Image = resp.Payload.ToString();
            }
            bool upRes = await _repository.UpdateAsync(entity);
            if (!upRes)
            {
                if (dto.Image != null) { _imageService.DeleteImage(basePath, newImageName); }
                return ServiceResponse.Failure("Невдалося оновити");
            }
            return ServiceResponse.Success($"Категорію {{{oldName}}} успішно оновлено", _mapper.CatToDto(entity));

        }


    }
}
