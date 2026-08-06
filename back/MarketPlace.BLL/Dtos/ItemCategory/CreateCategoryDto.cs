using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketPlace.BLL.Dtos.ItemCategory
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        public IFormFile? Image { get; set; }
    }
}
