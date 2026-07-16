using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities
{
    public class Merchant : BaseEntity//подумати над логікою продавець може бути покупцем
    {
        public string Name { get; set; } = string.Empty;
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Adress { get; set; }
        public List<ListingItem> ListingItems { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
