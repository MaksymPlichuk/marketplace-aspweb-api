using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities.Identity
{
    public class AppUserEntity : IdentityUser<string>
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string? Image { get; set; }

        public List<OrderEntity> BoughtOrders { get; set; } = [];//як у покупця багато замовлень
        public List<OrderEntity> SoldOrders { get; set; } = [];//продані вісять у профілі
        public List<ItemEntity> SellingItems { get; set; } = [];//продані просто на фронті вивести де sold=true
        public List<ReviewEntity> Reviews { get; set; } = [];


        //navigation props
        public virtual ICollection<AppUserClaimEntity> Claims { get; set; }
        public virtual ICollection<AppUserLoginEntity> Logins { get; set; }
        public virtual ICollection<AppUserTokenEntity> Tokens { get; set; }
        public virtual ICollection<AppUserRoleEntity> UserRoles { get; set; }
    }
}
