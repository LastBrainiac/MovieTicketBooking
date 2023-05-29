import { useContext, useEffect } from "react";
import { MovieContext } from "../MovieContext";
import SelectionHeader from "../components/seat-selection/SelectionHeader";
import SelectionBody from "../components/seat-selection/SelectionBody";
import SelectionFooter from "../components/seat-selection/SelectionFooter";
import CloseIcon from '@mui/icons-material/Close';
import { Link } from "react-router-dom";
import { Tooltip } from "@mui/material";

const SeatSelection = () => {
    const { screeningShortDate, screeningTime, selectedMovie, invokeAPIMethod, showFooter } = useContext(MovieContext);

    useEffect(() => {
        invokeAPIMethod(`booking?movieid=${selectedMovie.id}&screeningdate=${screeningShortDate} ${screeningTime}`, true);
    }, []);

    return (
        <div className="seat-selection-container">
            <Link to='/screening' onClick={() => showFooter()}>
                <Tooltip title='Back to screening dates' placement="left" arrow>
                    <CloseIcon sx={{ fontSize: '2em' }} className="close-icon" />
                </Tooltip>
            </Link>
            <SelectionHeader />
            <SelectionBody />
            <SelectionFooter />
        </div>
    )
}

export default SeatSelection;