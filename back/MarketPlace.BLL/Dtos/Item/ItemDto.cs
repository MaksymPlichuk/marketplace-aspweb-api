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
	public class ItemDto
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string Name { get; set; } = string.Empty;
		public string? Description { get; set; }
        public string Image { get; set; }

        public DateTime ListingExpiryDate { get; set; } = DateTime.UtcNow.AddDays(30);
		public decimal Price { get; set; } = 0m;
		public int Quantity { get; set; } = 0;

		public bool IsUsed { get; set; } = false;
		public bool IsSoldOut { get; set; } = false;

		public List<OrderForItemDto> Orders { get; set; } = [];

		public List<ReviewForItemDto> Reviews { get; set; } = [];
		public CategoryForItemOrderDto Category { get; set; }

		public UserForInfoDto Seller { get; set; }

	}
}
