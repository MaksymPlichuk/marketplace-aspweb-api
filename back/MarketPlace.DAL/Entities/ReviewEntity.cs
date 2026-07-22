using MarketPlace.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.DAL.Entities
{
    public class ReviewEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        public string AuthorId { get; set; }
        public AppUserEntity Author { get; set; }

        public int ItemId { get; set; }
        public ItemEntity Item { get; set; }
    }
}
