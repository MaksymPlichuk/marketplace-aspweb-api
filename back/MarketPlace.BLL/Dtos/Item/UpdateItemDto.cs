using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketPlace.BLL.Dtos.Item
{
    public class UpdateItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public IFormFile? Image { get; set; } = null;

        [Required]
        public decimal Price { get; set; } = 0m;
        [Required]
        public int Quantity { get; set; } = 0;
        [Required]
        public bool IsUsed { get; set; } = false;
        public int CategoryId { get; set; } //select
        public string SellerId { get; set; }
    }
}
