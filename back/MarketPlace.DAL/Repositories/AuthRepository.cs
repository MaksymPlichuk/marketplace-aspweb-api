using MarketPlace.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Repositories
{
    public class AuthRepository
    {
        private UserManager<AppUserEntity> _userManager;
        private AppDbContext _context;

        public AuthRepository(UserManager<AppUserEntity> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUserEntity> GetUserByIdAsync(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null) { return user; }
            return null;
        }
        public async Task<List<AppUserEntity>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            if (users != null) { return users; }
            return null;
        }
    }
}
