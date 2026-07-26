using MarketPlace.BLL.Dtos.Item;
using MarketPlace.BLL.Dtos.Order;
using MarketPlace.BLL.Dtos.Review;
using MarketPlace.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string? Image { get; set; }

        public List<OrderDto> BoughtOrders { get; set; } = [];//як у покупця багато замовлень
        public List<OrderDto> SoldOrders { get; set; } = [];//продані вісять у профілі
        public List<ItemDto> SellingItems { get; set; } = [];//продані просто на фронті вивести де sold=true
        public List<ReviewDto> Reviews { get; set; } = [];
    }
}
