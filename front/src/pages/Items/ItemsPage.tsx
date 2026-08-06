import {useGetItemsQuery} from "../../services/itemsApi.ts";
import {useEffect} from "react";
import ItemCard from "./ItemCard.tsx";
import type {IItemItem} from "../../types/IItemItem.ts";

const ItemsPage = () => {
    const {data: items, isLoading, isError} = useGetItemsQuery();

    useEffect(() => {
        if (items) {
            console.log(items)
        }
    }, [items])

    return (
        <div className={"flex justify-center mt-5  h-full flex-col justify-self-center text-center"}>
            <h1 className={"justify-self-center p-5 rounded-b-3xl bg-gray-200"}>Welcome to the shop! Choose
                item</h1>
            <div className="grid justify-center p-5 rounded-b-3xl h-full grid-cols-4 gap-5">
                {isLoading ? (<div>Loading...</div>) :
                    isError ? (<div>Error</div>) :
                        (
                            items &&
                            items.payload.map((item: IItemItem) => (
                                <ItemCard i={item}/>
                            )))
                }
                {/*найпростіший рендер <iframe src="https://www.youtube.com/embed/n-uWtKO6JDo"></iframe>*/}
                <video controls src={"http://localhost:5087/videos/davidLaid.mp4"}></video>
            </div>

        </div>
    )
}
export default ItemsPage