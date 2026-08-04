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

        public CategoryService(MapperProfile mapper, ItemCategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _repository.GetAll().Include(c=>c.Items).ToListAsync();
            if (entities == null) return ServiceResponse.Failure("Незнайдено категорій");

            return ServiceResponse.Success($"Знайдено {entities.Count()} категорій", _mapper.CatListToListDto(entities));

        }
        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var e = await _repository.GetByIdAsync(id);
            if (e == null) return ServiceResponse.Failure($"Категорію з id[{id}] не знайдено");
            return ServiceResponse.Success($"Категорію з id[{id}] знайдено", _mapper.CatToDto(e));
        }
    }
}
