import { useLocation } from "react-router-dom";
import Sessions from "../components/cinema-sessions/Sessions";

const ScreeningTimes = () => {
    const location = useLocation();
    const movie = location.state.movie;

    return (
        <main>
            <Sessions movie={movie} />
        </main>
    )
}

export default ScreeningTimes;