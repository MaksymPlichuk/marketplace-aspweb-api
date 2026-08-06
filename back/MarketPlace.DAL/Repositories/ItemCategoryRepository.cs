using MarketPlace.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<ItemCategoryEntity>> GetByNameAsync(string name)
        {
            var cat = await _context.ItemCategories.Include(c => c.Items).Where(c=>c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            if (cat == null) { return null; }
            return cat;
        }
    }
}
