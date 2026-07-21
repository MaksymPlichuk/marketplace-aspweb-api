using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities.Identity
{
    public class AppRoleClaimEntity : IdentityRoleClaim<string>
    {
        public virtual AppRoleEntity Role { get; set; }
    }
}
