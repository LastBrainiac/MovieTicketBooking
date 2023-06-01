import SessionHeader from "../components/cinema-sessions/SessionsHeader";
import SessionsBody from "../components/cinema-sessions/SessionsBody";
import CloseIcon from '@mui/icons-material/Close';
import { Link } from "react-router-dom";
import { Tooltip } from "@mui/material";

const ScreeningTimes = () => {
    return (
        <div className="cinema-sessions">
            <Link to='/'>
                <Tooltip title='Back to browsing movies' placement="left">
                    <CloseIcon sx={{ fontSize: '2em' }} className="close-icon" />
                </Tooltip>
            </Link>
            <SessionHeader />
            <SessionsBody />
        </div>
    )
}

export default ScreeningTimes;