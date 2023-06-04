import CloseIcon from '@mui/icons-material/Close';
import { Link, useNavigate } from "react-router-dom";
import { Tooltip } from "@mui/material";
import { useContext } from 'react';
import { MovieContext } from '../MovieContext';
import SentimentSatisfiedAltIcon from '@mui/icons-material/SentimentSatisfiedAlt';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { ThemeProvider } from '@mui/material/styles';
import DeleteIcon from '@mui/icons-material/Delete';
import * as Common from '../shared/common';
import ForwardIcon from '@mui/icons-material/Forward';

const ShoppingCart = () => {
    const { cartItems, deleteCartItem } = useContext(MovieContext);
    const navigate = useNavigate();

    const total = () => {
        return cartItems.map(item => item.ticketPrice * item.ticketQuantity).reduce((sum, i) => sum + i, 0);
    }

    return (
        <div className="shopping-cart">
            <Link to='/'>
                <Tooltip title='Back to browsing movies' placement="left">
                    <CloseIcon sx={{ fontSize: '2em' }} className="close-icon" />
                </Tooltip>
            </Link>
            <h2>My Bookings</h2>
            <div className='cart-items'>
                {
                    cartItems && cartItems.length > 0
                        ?
                        <div className='items-container'>
                            <ThemeProvider theme={Common.darkTheme}>
                                <TableContainer component={Paper}>
                                    <Table sx={{ minWidth: 400 }}>
                                        <TableHead>
                                            <TableRow>
                                                <TableCell>Movie Title</TableCell>
                                                <TableCell align="right">Screening Date</TableCell>
                                                <TableCell align="right">Ticket Quantity</TableCell>
                                                <TableCell align="right">Ticket Price</TableCell>
                                                <TableCell align="right">Subtotal</TableCell>
                                                <TableCell></TableCell>
                                            </TableRow>
                                        </TableHead>
                                        <TableBody>
                                            {cartItems.map((cartItem, index) => (
                                                <TableRow key={index}>
                                                    <TableCell component="th" scope="row">
                                                        {cartItem.movieTitle}
                                                    </TableCell>
                                                    <TableCell align="right">{Common.mediumDateShortTime.format(new Date(cartItem.screeningDate))}</TableCell>
                                                    <TableCell align="right">{cartItem.ticketQuantity}</TableCell>
                                                    <TableCell align="right">{cartItem.ticketPrice.toLocaleString('hu-HU', { style: 'currency', currency: 'HUF' })}</TableCell>
                                                    <TableCell align="right">{(cartItem.ticketQuantity * cartItem.ticketPrice).toLocaleString('hu-HU', { style: 'currency', currency: 'HUF' })}</TableCell>
                                                    <TableCell align="right">
                                                        <DeleteIcon className="delete" onClick={() => deleteCartItem(cartItem.movieId)} />
                                                    </TableCell>
                                                </TableRow>
                                            ))}
                                            <TableRow sx={{ '&:last-child td': { border: 0 } }}>
                                                <TableCell rowSpan={2} />
                                                <TableCell align='right' colSpan={3}>Total</TableCell>
                                                <TableCell align="right">{total().toLocaleString('hu-HU', { style: 'currency', currency: 'HUF' })}</TableCell>
                                            </TableRow>
                                        </TableBody>
                                    </Table>
                                </TableContainer>
                            </ThemeProvider>
                            <div className="add-to-cart btn-forward">
                                <button className="btn btn-add-to-cart" onClick={() => navigate('/userinfo')}>
                                    <ForwardIcon sx={{ fontSize: '3em' }} />
                                </button>
                            </div>
                        </div>
                        :
                        <div className='empty-cart-message'>
                            <p>It seems your cart is empty. Select your favorite movies and watch them!</p>
                            <SentimentSatisfiedAltIcon />
                        </div>
                }
            </div>
        </div>
    )
}

export default ShoppingCart;