import { useLocation } from "react-router-dom";

const ScreeningTimes = () => {    
    const location = useLocation();
    const movie = location.state.movie;

    return (
        <p>ScreeningTimes Page</p>
    )
}

export default ScreeningTimes;