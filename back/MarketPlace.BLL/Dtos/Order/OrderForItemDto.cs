using MarketPlace.BLL.Dtos.Auth;
using MarketPlace.BLL.Dtos.Item;
using MarketPlace.BLL.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.Order
{
    public class OrderForItemDto //для Item при виводі
    {
        public int Id { get; set; }
        public UserForInfoDto Buyer { get; set; }
        public UserForInfoDto Seller { get; set; }
        public decimal FinalPrice { get; set; } = 0m;
    }
}
