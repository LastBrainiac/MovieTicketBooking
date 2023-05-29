import { useContext } from "react";
import { MovieContext } from "../../MovieContext";
import { Tooltip } from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import SelectedSeat from "./viewing-area/SelectedSeat";

const SelectionFooter = () => {    
    const { selectedSeats } = useContext(MovieContext);
    const selectedSeatsClass = selectedSeats.length > 0 ? "show-selected-seats" : ""

    const selectedSeatList = selectedSeats.map((seat, index) => {
        return (
            <SelectedSeat key={index} row={seat.row} number={seat.number} />
        )
    })

    return (
        <div className="selection-footer-container">
            <div className={`selection-footer ${selectedSeatsClass}`} >
                <div className="selected-seats">
                    <p>SEATS</p>
                    <div className="selected-seat-list">
                        {selectedSeatList}
                    </div>
                    <div className="total-price">
                        <p>Total {selectedSeats.length * 2500} HUF</p>                        
                    </div>
                </div>
                <div className="add-to-cart">
                    <button className="btn btn-add-to-cart">
                        <Tooltip title='Add to My Bookings' arrow placement="right-start">
                            <AddIcon sx={{ fontSize: '3em' }} />
                        </Tooltip>
                    </button>
                </div>
            </div>
        </div>
    )
}

export default SelectionFooter;