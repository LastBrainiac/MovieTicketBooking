import * as GlobalVariables from '../../../shared/globals.js';
import { useContext, useState } from "react";
import { MovieContext } from "../../../MovieContext";
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';

const Seat = ({ seat, row }) => {
    const [open, setOpen] = useState(false);
    const { selectedSeatToggle, selectedSeatHandler, selectedSeats } = useContext(MovieContext);
    const seatStatusClass = seat.booked ? "square-unavailable" : seat.isSelected ? "square-selected" : "square-available";

    const clickHandler = (seatObj) => {
        let seatNotBookedAndSelectedSeatCountIsOk = false;
        let seatIsSelectedAndSeatCountReachedMaxValue = false;

        if (selectedSeats.length < GlobalVariables.maxTicketCount) {
            if (!seatObj.seat.booked) seatNotBookedAndSelectedSeatCountIsOk = true;
        } else {
            if (!seatObj.seat.isSelected && !seatObj.seat.booked) setOpen(true);
            else seatIsSelectedAndSeatCountReachedMaxValue = true;
        }

        if (!seatObj.seat.booked && (seatNotBookedAndSelectedSeatCountIsOk || seatIsSelectedAndSeatCountReachedMaxValue)) {
            selectedSeatToggle(seatObj.row, seatObj.seat.seatNumber);
            selectedSeatHandler({ row: row, number: seat.seatNumber }, seat.isSelected);
        }
    }

    const closeHandler = () => {
        setOpen(false);
    };

    return (
        <div>
            <div className={`square seat-square ${seatStatusClass}`} onClick={() => clickHandler({ row: row, seat: seat })}>
                <span>{seat.seatNumber}</span>
            </div>
            <Dialog
                open={open}
                onClose={closeHandler}
                fullWidth={true}
            >
                <DialogTitle sx={{ backgroundColor: 'rgb(179, 65, 20)', color: 'antiquewhite' }}>
                    {"Warning!"}
                </DialogTitle>
                <DialogContent sx={{ backgroundColor: 'rgb(179, 65, 20)' }}>
                    <DialogContentText sx={{ color: 'antiquewhite' }}>
                        You can book maximum {GlobalVariables.maxTicketCount} ticket!
                    </DialogContentText>
                </DialogContent>
                <DialogActions sx={{ backgroundColor: 'rgb(179, 65, 20)' }}>
                    <Button sx={{ backgroundColor: 'darkred', color: 'antiquewhite' }} onClick={closeHandler}>Ok</Button>
                </DialogActions>
            </Dialog>
        </div>
    )
}

export default Seat;