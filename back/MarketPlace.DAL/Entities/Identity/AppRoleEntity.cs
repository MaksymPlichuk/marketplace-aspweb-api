using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities.Identity
{
    public class AppRoleEntity: IdentityRole
    {
        public virtual ICollection<AppUserRoleEntity> UserRoles { get; set; }
        public virtual ICollection<AppRoleClaimEntity> RoleClaims { get; set; }
    }
}
