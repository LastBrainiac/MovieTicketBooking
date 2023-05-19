import SessionHeader from "./SessionsHeader";
import SessionsBody from "./SessionsBody";

const Sessions = ({ movie }) => {

    return (
        <div className="cinema-sessions">
            <SessionHeader movie={movie} />
            <SessionsBody startTimes={movie.startTimes} />
        </div>
    )
}

export default Sessions;