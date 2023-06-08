import CloseIcon from '@mui/icons-material/Close';
import { Link, useNavigate } from "react-router-dom";
import { Tooltip } from "@mui/material";
import { useContext } from 'react';
import { MovieContext } from '../MovieContext';
import SentimentSatisfiedAltIcon from '@mui/icons-material/SentimentSatisfiedAlt';
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
                            <table className="table-items">
                                <thead>
                                    <tr className='title-row'>
                                        <th className='t-left'>Movie Title</th>
                                        <th className='t-right'>Screening Date</th>
                                        <th className='t-right'>Ticket Quantity</th>
                                        <th className='t-right'>Ticket Price</th>
                                        <th className='t-right'>Subtotal</th>
                                        <th className='t-right'></th>
                                    </tr>
                                </thead>
                                <tbody className='t-body'>
                                    {cartItems.map((cartItem, index) => (
                                        <tr key={index}>
                                            <td>{cartItem.movieTitle}</td>
                                            <td className='t-right'>{Common.mediumDateShortTime.format(new Date(cartItem.screeningDate))}</td>
                                            <td className='t-right'>{cartItem.ticketQuantity}</td>
                                            <td className='t-right'>{cartItem.ticketPrice}</td>
                                            <td className='t-right'>{(cartItem.ticketQuantity * cartItem.ticketPrice)}</td>
                                            <td className='t-center'><DeleteIcon className="delete" onClick={() => deleteCartItem(cartItem.movieId)} /></td>
                                        </tr>
                                    ))}
                                </tbody>
                                <tfoot>
                                    <tr className='t-foot'>
                                        <td colSpan="3"></td>
                                        <td><strong>Total</strong></td>
                                        <td><strong>{total()}&nbsp;HUF</strong></td>
                                    </tr>
                                </tfoot>
                            </table>
                            <div className="add-to-cart btn-forward">
                                <button className="btn btn-add-to-cart" onClick={() => navigate('/userinfo')}>
                                    <ForwardIcon sx={{ fontSize: '2.5em' }} />
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