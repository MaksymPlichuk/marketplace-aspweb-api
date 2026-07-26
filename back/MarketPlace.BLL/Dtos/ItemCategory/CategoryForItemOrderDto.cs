using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.ItemCategory
{
    public class CategoryForItemOrderDto //для Item і OrderItem назва і картинка 
    {
        //public int Id { get; set; } //може приберу для показу в корзині
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
    }
}
