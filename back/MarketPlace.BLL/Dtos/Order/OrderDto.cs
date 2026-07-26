using MarketPlace.BLL.Dtos.Auth;
using MarketPlace.BLL.Dtos.Item;
using MarketPlace.BLL.Dtos.User;
using MarketPlace.DAL.Entities;
using MarketPlace.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public UserForInfoDto Buyer { get; set; }
        public UserForInfoDto Seller { get; set; }

        public List<ItemForOrderDto> Items { get; set; } = [];

        public decimal FinalPrice { get; set; } = 0m;
        public string OrderStatus { get; set; } = "Pending";
    }
}
