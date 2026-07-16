using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities
{
    public class Review : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int? ListingItemId { get; set; }
        public ListingItem? ListingItem { get; set; }
    }
}
