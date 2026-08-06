import type {IUserForInfoItem} from "./AdditionalItems/IUserForInfoItem.ts";
import type {IOrderForItemItem} from "./AdditionalItems/IOrderForItemItem.ts";
import type {ICategoryForInfoItem} from "./AdditionalItems/ICategoryForItemOrderItem.ts";
import type {IReviewForItemItem} from "./AdditionalItems/IReviewForItemItem.ts";

export interface IItemItem {
    id: string,
    creationDate: string,
    name: string,
    description: string | null,
    image: string,
    listingExpiryDate: string,

    price: string,
    quantity: string,
    isUsed: boolean,
    isSoldOut: boolean,

    seller: IUserForInfoItem,
    orders: IOrderForItemItem[],
    reviews: IReviewForItemItem[],
    category: ICategoryForInfoItem,

}