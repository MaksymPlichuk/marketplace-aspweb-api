using MarketPlace.BLL.Dtos.Auth;
using MarketPlace.BLL.Dtos.ItemCategory;
using MarketPlace.BLL.Dtos.Order;
using MarketPlace.BLL.Dtos.Review;
using MarketPlace.BLL.Dtos.User;
using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.Item
{
    public class ItemForOrderDto //для Order при виводі списку товарів в замовлені
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0m;
        public int Quantity { get; set; } = 0;

        public bool IsUsed { get; set; } = false;
        public UserForInfoDto Seller { get; set; }

        public CategoryForItemOrderDto Category { get; set; }
    }
}
