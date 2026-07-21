using MarketPlace.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities
{
    public class OrderEntity : BaseEntity
    {
        public string BuyerId { get; set; } = string.Empty;
        public AppUserEntity Buyer { get; set; }
        public string SellerId { get; set; }
        public AppUserEntity Seller { get; set; }

        public List<ItemEntity> Items { get; set; } = [];

        public decimal FinalPrice { get; set; }
        public string OrderStatus { get; set; } = "Pending";

    }
    //public enum OrderStatus//статуси замовлень
    //{
    //    Pending,
    //    Paid,
    //    Shipping,
    //    Shipped,
    //    Cancelled,
    //    Completed
    //}
}
