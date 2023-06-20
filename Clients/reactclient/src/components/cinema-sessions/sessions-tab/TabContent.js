import { Link } from "react-router-dom";
import { useContext, useEffect } from "react";
import { MovieContext } from "../../../MovieContext";

const TabContent = () => {
    const { selectedMovie, storeScreeningTime, startTimeIndex } = useContext(MovieContext);

    const screeningTimeButtons = selectedMovie?.startTimes[startTimeIndex]?.map((times, index) => {
        return (
            <Link className="start-times" to='/selectseat' onClick={() => storeScreeningTime(times)} key={index}>
                <p>{times}</p>
            </Link>
        )
    });

    return (
        <div className="tab-content">
            {screeningTimeButtons?.length > 0 ? screeningTimeButtons : <p className="not-showing">This movie is not showing today</p> }
        </div>
    )
}

export default TabContent;