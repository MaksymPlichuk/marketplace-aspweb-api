import {useGetItemsQuery} from "../services/itemsApi.ts";
import {useEffect} from "react";

const MainPage = () => {

    //простий перепис у змінну
    const {data: items, isLoading, isError} = useGetItemsQuery();

    useEffect(() => {
        if (items) {
            console.log(items)
        }
    }, [items])

    return (
        <div className={"flex justify-center mt-5  h-full flex-col justify-self-center text-center"}>
            <h1 className={"justify-self-center p-5 rounded-b-3xl bg-gray-200"}>Welcome to the shop! Choose
                category</h1>
            <div className="flex justify-center p-5 rounded-b-3xl h-full">
                {isLoading ? (<div>Loading...</div>) :
                    isError ? (<div>Error</div>) :
                        (
                            items &&
                            items.payload.map((i) => (
                                <div className="max-w-sm rounded overflow-hidden shadow-lg m-5" key={i.id}>//todo grid
                                    <img className="w-full"
                                         src={i.image ? i.image : "https://t4.ftcdn.net/jpg/04/70/29/97/360_F_470299797_UD0eoVMMSUbHCcNJCdv2t8B2g1GVqYgs.jpg"}
                                         alt={i.name}/>
                                    <div className="px-6 py-4">
                                        <div className="font-bold text-xl mb-2">{i.name}</div>
                                        <p className="text-gray-700 text-base">
                                            {i.description}
                                        </p>
                                    </div>
                                    <div className="px-6 pt-4 pb-2">
                        <span
                            className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">#photography</span>
                                        <span
                                            className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">#travel</span>
                                        <span
                                            className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">#winter</span>
                                    </div>
                                </div>
                            )))}
            </div>

        </div>
    )
}
export default MainPage;