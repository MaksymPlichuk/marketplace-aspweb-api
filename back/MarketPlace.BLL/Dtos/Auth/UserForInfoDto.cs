using MarketPlace.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.Auth
{
    public class UserForInfoDto //Для Reviews Orders Items і похідних як Author Seller Buyer
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? Image { get; set; }

    }
}
