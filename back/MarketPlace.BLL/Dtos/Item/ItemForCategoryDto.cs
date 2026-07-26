using MarketPlace.BLL.Dtos.ItemCategory;
using MarketPlace.BLL.Dtos.Order;
using MarketPlace.BLL.Dtos.Review;
using MarketPlace.BLL.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.Item
{
    public class ItemForCategoryDto //для Review коротко про товар і для ItemCategory
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
