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
            var allItems = await base.GetAll()  //неоптимізовано
                .Include(i=>i.Category).Include(i=>i.Reviews).ThenInclude(r=>r.Author)
                .Include(i=>i.Seller)
                .Include(i=>i.Orders).ThenInclude(o=>o.Seller)
                .Include(i => i.Orders).ThenInclude(o => o.Buyer)
                .ToListAsync();

            //foreach (var item in allItems)
            //{
            //    item.Name = item.Name.ToLower();
            //}
            string queryName = name.ToLower();

            //List<ItemEntity> res = allItems.Where(i => i.Name.Contains(queryName)).ToList();

            //if (res == null) { return null; }
            //return res;

            List<ItemEntity> items = allItems.Where(i => i.Name.ToLower().Contains(queryName)).ToList();
            if (items == null) { return null; }
            return items;
        }
    }
}
