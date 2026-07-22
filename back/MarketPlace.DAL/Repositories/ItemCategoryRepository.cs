using MarketPlace.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Repositories
{
    public class ItemCategoryRepository : GenericRepository<ItemCategoryEntity>
    {
        private AppDbContext _context;
        public ItemCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public ItemCategoryEntity GetByName(string name)
        {
            var cat = _context.ItemCategories.FirstOrDefault(c=>c.Name == name);
            if (cat == null) { return null; }
            return cat;
        }
    }
}
