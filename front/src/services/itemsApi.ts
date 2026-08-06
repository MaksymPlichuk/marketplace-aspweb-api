import {createBaseQuery} from "../utils/CreateBaseQuery.ts";
import type {IItemItem} from "../types/IItemItem.ts";
import {createApi} from "@reduxjs/toolkit/query/react";

export const itemsApi = createApi({
    baseQuery: createBaseQuery("item"),
    tagTypes: ['items'], //щоб RTK Query знав коли треба автоматично оновити список items
    reducerPath: 'itemsApi',
    endpoints : (builder) => ({

        getItems: builder.query<IItemItem[], void>({
            query: () => {
                return {
                    url: '/',
                    method: 'GET'
                }
            }
        }),
        //post put delete
    })
})

export const {
    useGetItemsQuery
} = itemsApi;