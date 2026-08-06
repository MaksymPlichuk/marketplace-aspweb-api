import type {IUserForInfoItem} from "./IUserForInfoItem.ts";

export interface IOrderForItemItem {
    id: string,
    buyer: IUserForInfoItem,
    seller: IUserForInfoItem,
    finalPrice: number,
}
