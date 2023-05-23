import { useContext } from "react";
import { MovieContext } from "../../../MovieContext";

const TabItem = ({ data }) => {
    const { setDayIsSelected } = useContext(MovieContext);
    const itemClass = data.isSelected ? 'tab-item-selected' : 'tab-item';

    const clickHandler = () => {
        setDayIsSelected(data);
    }

    return (
        <div className={`${itemClass}`} onClick={clickHandler}>
            <p className="day">{data.day}</p>
            <p>{data.dayName}</p>
        </div>
    )
}

export default TabItem;