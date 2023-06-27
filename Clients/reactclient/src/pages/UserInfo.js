import { useContext, useState } from 'react';
import TextField from '@mui/material/TextField';
import { ThemeProvider } from '@mui/material/styles';
import * as Common from '../shared/common';
import CloseIcon from '@mui/icons-material/Close';
import { Link, useNavigate } from "react-router-dom";
import { Tooltip } from "@mui/material";
import { MovieContext } from '../MovieContext';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';

const UserInfo = () => {
    const navigate = useNavigate();
    const { setCheckoutAPICallParams, checkoutBasket, deleteBasket } = useContext(MovieContext);
    const [open, setOpen] = useState(false);
    const [formData, setFormData] = useState(
        {
            fullName: "",
            emailAddress: "",
            phoneNumber: ""
        }
    );

    const style = {
        position: 'absolute',
        top: '50%',
        left: '50%',
        transform: 'translate(-50%, -50%)',
        width: 300,
        bgcolor: 'var(--successful-bg)',
        color: 'black',
        border: '2px solid #000',
        borderRadius: '10px',
        p: 3,
    };

    const closeHandler = () => {
        setOpen(false);
        navigate('/');
    }

    const changeHandler = (e) => {
        const { name, value } = e.target;
        setFormData(prevFormData => {
            return {
                ...prevFormData,
                [name]: value
            }
        })
    }

    const submitHandler = (e) => {
        e.preventDefault();
        setCheckoutAPICallParams({ ...formData, basketId: localStorage.getItem('basketid') });
        checkoutBasket();
        deleteBasket();
        setOpen(true);
    }

    return (
        <div className="user-info-container">
            <Link to='/cart'>
                <Tooltip title='Back to My Bookings' placement="left">
                    <CloseIcon className="close-icon" />
                </Tooltip>
            </Link>
            <p>Please enter the necessary information for bookings</p>
            <form onSubmit={submitHandler}>
                <div className='info-form'>
                    <ThemeProvider theme={Common.darkTheme}>
                        <TextField required sx={{ marginRight: '1em', width: '100%' }} label="Full Name" variant="outlined" onChange={changeHandler} name='fullName' value={formData.fullName} autoFocus />
                        <TextField required type='email' sx={{ marginRight: '1em', width: '100%' }} label="Email Address" variant="outlined" onChange={changeHandler} name='emailAddress' value={formData.emailAddress} />
                        <TextField sx={{ width: '100%' }} label="Phone Number" variant="outlined" onChange={changeHandler} name='phoneNumber' value={formData.phoneNumber} />
                    </ThemeProvider>
                </div>
                <button className="btn btn-submit">SUBMIT</button>
            </form>
            <Modal open={open}>
                <Box sx={style}>
                    <Typography variant="h6" component="h2" sx={{ mb: 2 }}>
                        BOOKING IS SUCCESSFUL
                    </Typography>
                    <Divider />
                    <Typography sx={{ mt: 2 }}>
                        The notification e-mail was sent to the following e-mail address:
                    </Typography>
                    <Typography sx={{ mt: 1 }}>
                        {formData.emailAddress}
                    </Typography>
                    <button className='btn btn-success' onClick={closeHandler}>OK</button>
                </Box>
            </Modal>
        </div>
    )
}

export default UserInfo;