using MarketPlace.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Repositories
{
    public class ItemRepository : GenericRepository<ItemEntity>
    {
        private AppDbContext _context;
        public ItemRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<ItemEntity>> FindItemsByNameAsync(string name)
        {
            var allItems = await base.GetAllAsync().ToListAsync();
            foreach (var item in allItems)
            {
                item.Name = item.Name.ToLower();
            }
            string queryName = name.ToLower();

            List<ItemEntity> res = allItems.Where(i => i.Name.Contains(queryName)).ToList();

            if (res == null) { return null; }
            return res;

            //allItems.Select(i => i.Name == i.Name.ToLower());
            //List<ItemEntity> items = await _context.Items.Where(i=>i.Name==name).ToListAsync();
            //if (items == null) { return null; }
            //return items;
        }
    }
}
