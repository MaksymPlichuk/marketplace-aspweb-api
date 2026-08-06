import APP_ENV from "../../env";
import type {IItemItem} from "../../types/IItemItem.ts";

interface IItemCardProps {  //для деструктуризації пропс і надавання їм типів [ i: IItemItem, likebtn: ILikebtn ]
    i: IItemItem;
}

const ItemCard = ({i}: IItemCardProps) => {
    return (
        <div className="max-w-sm rounded overflow-hidden shadow-lg m-5" key={i.id}>
            <img className="w-full"
                 src={i.image ? `${APP_ENV.BACK_IMAGE_URL}/${i.image}`
                     : "https://t4.ftcdn.net/jpg/04/70/29/97/360_F_470299797_UD0eoVMMSUbHCcNJCdv2t8B2g1GVqYgs.jpg"}
                 alt={i.name}/>
            <div className="px-6 py-4">
                <div className="font-bold text-xl mb-2">{i.name}</div>
                <p className="text-gray-700 text-base">
                    {i.description}
                </p>
            </div>
            {i.reviews.length > 0 &&
                <div className="px-6 pt-4 pb-2">
                    {i.reviews.slice(0,4).map((review, index) => (
                        <span key={review.id || index}
                              className="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2">{review.title}</span>
                    ))}
                </div>
            }
        </div>
    );
}
export default ItemCard;