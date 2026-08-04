import {fetchBaseQuery} from "@reduxjs/toolkit/query";
import APP_ENV from "../env";
                                                    //endpoint=продовження URL (/items /category)
export const createBaseQuery = (endpoint: string) => {
    return fetchBaseQuery({
        baseUrl: `${APP_ENV.API_URL}/api/${endpoint}`,
    })
}
