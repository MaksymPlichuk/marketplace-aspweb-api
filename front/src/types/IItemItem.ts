export interface IItemItem {
    Id: string,
    CreationDate: string,
    Name: string,
    Description: string | null,
    Image: string,

    Price: string,
    Quantity: string,
    IsUsed: boolean,
    IsSoldOut: boolean,
}
// public DateTime CreationDate { get; set; }
//
// public DateTime ListingExpiryDate { get; set; } = DateTime.UtcNow.AddDays(30);
//
// public List<OrderForItemDto> Orders { get; set; } = [];
//
// public List<ReviewForItemDto> Reviews { get; set; } = [];
// public CategoryForItemOrderDto Category { get; set; }
//
// public UserForInfoDto Seller { get; set; }