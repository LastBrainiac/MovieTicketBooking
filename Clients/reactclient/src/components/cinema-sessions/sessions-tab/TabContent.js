import { Link } from "react-router-dom";
import { useContext } from "react";
import { MovieContext } from "../../../MovieContext";

const TabContent = () => {
    const { selectedMovie } = useContext(MovieContext);

    const screeningTimeButtons = selectedMovie.startTimes.map(time => {
        return (
            <Link className="start-times" to='/selectseat' key={time}>
                <p>{time}</p>
            </Link>
        )
    });

    return (
        <div className="tab-content">
            {screeningTimeButtons}
        </div>
    )
}

export default TabContent;