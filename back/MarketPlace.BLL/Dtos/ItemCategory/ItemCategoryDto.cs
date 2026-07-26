using MarketPlace.BLL.Dtos.Item;
using MarketPlace.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.ItemCategory
{
    public class ItemCategoryDto //Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<ItemForCategoryDto> Items { get; set; } = [];
    }
}
