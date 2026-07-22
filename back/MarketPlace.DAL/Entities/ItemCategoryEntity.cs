using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities
{
    public class ItemCategoryEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public List<ItemEntity> Items { get; set; } = [];
    }
}
