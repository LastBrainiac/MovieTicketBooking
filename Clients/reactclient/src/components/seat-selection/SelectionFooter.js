import { useContext } from "react";
import { MovieContext } from "../../MovieContext";
import { Tooltip } from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import SelectedSeat from "./viewing-area/SelectedSeat";
import * as GlobalVariables from '../../shared/globals';
import { useNavigate } from "react-router-dom";

const SelectionFooter = () => {
    const navigate = useNavigate();
    const { selectedSeats, addItemToCart, selectedMovie, screeningShortDate, screeningTime, showFooter } = useContext(MovieContext);
    const selectedSeatsClass = selectedSeats.length > 0 ? "show-selected-seats" : "";

    const selectedSeatList = selectedSeats.map((seat, index) => {
        return (
            <SelectedSeat key={index} row={seat.row} number={seat.number} />
        )
    })

    const clickHandler = () => {
        const cartItem = {
            movieId: selectedMovie.id,
            movieTitle: selectedMovie.title,
            ticketQuantity: selectedSeats.length,
            ticketPrice: GlobalVariables.ticketPrice,
            screeningDate: new Date(`${screeningShortDate} ${screeningTime}`),
            bookedSeats: selectedSeats
        }
        addItemToCart(cartItem);
        showFooter();
        navigate('/');
    }

    return (
        <div className="selection-footer-container">
            <div className={`selection-footer ${selectedSeatsClass}`} >
                <div className="selected-seats">
                    <p>SEATS</p>
                    <div className="selected-seat-list">
                        {selectedSeatList}
                    </div>
                    <div className="total-price">
                        <p>Total {selectedSeats.length * GlobalVariables.ticketPrice} HUF</p>
                    </div>
                </div>
                <div className="add-to-cart">
                    <button className="btn btn-add-to-cart" onClick={clickHandler}>
                        <Tooltip title='Add to My Bookings' placement="top">
                            <AddIcon sx={{ fontSize: '2.5em' }} />
                        </Tooltip>
                    </button>
                </div>
            </div>
        </div>
    )
}

export default SelectionFooter;