using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities
{
    public class ListingItem : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public DateTime ExpiryDate { get; set; }
        public int Price { get; set; }
        public bool IsUsed { get; set; }

        public int? VendorId { get; set; }
        public Vendor? Vendor { get; set; }

        public List<Review> Reviews { get; set; } = [];
    }
}
