using MarketPlace.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities
{
    public class ItemEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }

        //для реклами
        public DateTime ListingExpiryDate { get; set; } = DateTime.UtcNow.AddDays(30);
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;

        public bool IsUsed { get; set; } = false;
        public bool IsSoldOut { get; set; } = false;
        public List<OrderEntity> Orders { get; set; } = [];

        public List<ReviewEntity> Reviews { get; set; } = [];
        public string SellerId { get; set; }
        public AppUserEntity Seller { get; set; }

        public int CategoryId { get; set; }
        public ItemCategoryEntity Category{ get; set; }
    }
}
