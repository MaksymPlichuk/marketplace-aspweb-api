import type {IUserForInfoItem} from "./IUserForInfoItem.ts";

export interface IReviewForItemItem {
    id: number,
    title: string,
    description: string,
    rating: number,
    author: IUserForInfoItem,
}