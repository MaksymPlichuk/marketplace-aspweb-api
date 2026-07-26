using MarketPlace.BLL.Dtos.Auth;
using MarketPlace.BLL.Dtos.Item;
using MarketPlace.BLL.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.BLL.Dtos.Review
{
    public class ReviewForItemDto //Для Item щоб не дублювати товари
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public UserForInfoDto Author { get; set; }
    }
}
