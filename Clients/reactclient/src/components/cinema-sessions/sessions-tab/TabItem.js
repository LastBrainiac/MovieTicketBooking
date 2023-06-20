import { useContext } from "react";
import { MovieContext } from "../../../MovieContext";

const TabItem = ({ data, index }) => {
    const { setDayIsSelected } = useContext(MovieContext);
    const itemClass = data.isSelected ? 'tab-item-selected' : 'tab-item';

    return (
        <div className={`${itemClass}`} onClick={() => setDayIsSelected(data, index)}>
            <p className="day">{data.day}</p>
            <p>{data.dayName}</p>
        </div>
    )
}

export default TabItem;