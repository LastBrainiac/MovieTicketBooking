import SessionHeader from "./SessionsHeader";
import SessionsBody from "./SessionsBody";
import CloseIcon from '@mui/icons-material/Close';
import { Link } from "react-router-dom";
import { Tooltip } from "@mui/material";

const Sessions = () => {
    return (
        <div className="cinema-sessions">
            <Link to='/'>
                <Tooltip title='Back to browsing movies' placement="left" arrow>
                    <CloseIcon sx={{ fontSize: '2em' }} className="close-icon" />
                </Tooltip>
            </Link>
            <SessionHeader />
            <SessionsBody />
        </div>
    )
}

export default Sessions;