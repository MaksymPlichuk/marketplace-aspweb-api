using MarketPlace.BLL.Dtos.Item;
using MarketPlace.BLL.Dtos.ItemCategory;
using MarketPlace.BLL.Dtos.Order;
using MarketPlace.BLL.Dtos.Review;
using MarketPlace.BLL.Dtos.User;
using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Entities.Identity;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Mapperly
{
    [Mapper(UseDeepCloning = true, RequiredMappingStrategy = RequiredMappingStrategy.Source)]
    public partial class MapperProfile
    {
        //[MapperIgnoreSource(nameof(ItemEntity.Seller))]
        //[MapProperty(nameof(ItemEntity.Name), nameof(ItemDto.Name))]
        public partial ItemDto ItemToItemDto(ItemEntity item);

        [MapperIgnoreSource(nameof(CreateItemDto.Image))]
        [MapperIgnoreTarget(nameof(ItemEntity.Image))]
        public partial ItemEntity CreateDtoToItemEntity(CreateItemDto dto);
        public partial List<ItemDto> ItemsToItemDtos(List<ItemEntity> item);

        public partial UserDto UserToUserDto(AppUserEntity appUser);
        public partial List<UserDto> UsersToUserDtos(List<AppUserEntity> appUser);

        [MapperIgnoreSource(nameof(CreateItemDto.Image))]
        [MapperIgnoreTarget(nameof(ItemEntity.Image))]
        public partial void UpdateItem(UpdateItemDto dto, [MappingTarget]ItemEntity entity); //не створить новий

        public partial ItemCategoryDto CatToDto(ItemCategoryEntity entity);
        public partial List<ItemCategoryDto> CatListToListDto(List<ItemCategoryEntity> entity);

        [MapperIgnoreSource(nameof(CreateCategoryDto.Image))]
        [MapperIgnoreTarget(nameof(ItemEntity.Image))]
        public partial ItemCategoryEntity CreateCatToEntity(CreateCategoryDto dto);

        [MapperIgnoreSource(nameof(UpdateCategoryDto.Image))]
        [MapperIgnoreTarget(nameof(ItemEntity.Image))]
        public partial void UpdateCatToEntity(UpdateCategoryDto dto, [MappingTarget]ItemCategoryEntity entity);
    }
}
