using MarketPlace.BLL.Dtos.Auth;
using MarketPlace.BLL.Dtos.ItemCategory;
using MarketPlace.BLL.Dtos.Order;
using MarketPlace.BLL.Dtos.Review;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketPlace.BLL.Dtos.Item
{
    public class CreateItemDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public decimal Price { get; set; } = 0m;
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public bool IsUsed { get; set; } = false;
        public int CategoryId { get; set; } //select

    }
}
