import { Link } from "react-router-dom";

const TabContent = ({ startTimes }) => {

    const screeningTimeButtons = startTimes.map(time => {
        return (
            <Link className="start-times" to='/selectseat' state={{  }}  key={time}>
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