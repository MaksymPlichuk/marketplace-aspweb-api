using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities.Identity
{
    public class AppUserLoginEntity : IdentityUserLogin<string>
    {
        public virtual AppUserEntity User { get; set; }
    }
}
