import { createContext, useEffect, useState } from 'react';
import * as GlobalVariables from './shared/globals.js';
import * as Common from './shared/common.js';
import { createId } from '@paralleldrive/cuid2';

const MovieContext = createContext();

const MovieContextProvider = (props) => {
    const [allMovies, setAllMovies] = useState([]);
    const [cartItems, setCartItems] = useState([]);
    const [loading, setLoading] = useState(false);
    const [selectedMovie, setSelectedMovie] = useState({});
    const [screeningData, setScreeningData] = useState([]);
    const [screeningShortDate, setScreeningShortDate] = useState('');
    const [screeningTime, setScreeningTime] = useState('');
    const [callAPITrigger, setCallAPITrigger] = useState(false);
    const [apiEndPoint, setAPIEndPoint] = useState('');
    const [apiResponse, setAPIResponse] = useState([]);
    const [hideFooter, setHideFooter] = useState(false);
    const [selectedSeats, setSelectedSeats] = useState([]);
    const [saveBasketTrigger, setSaveBasketTrigger] = useState(false);
    const [checkoutObj, setCheckoutObj] = useState({});
    const [checkoutBasketTrigger, setCheckoutBasketTrigger] = useState(false);

    useEffect(() => {
        setLoading(true);
        const getMovies = async () => {
            const response = await fetch(`${GlobalVariables.apiBaseUrl}api/movies`);
            const data = await response.json();
            setAllMovies(data);
            setLoading(false);
        }
        getMovies();
        getScreeningData();
    }, []);

    useEffect(() => {
        const callAPI = async () => {
            if (callAPITrigger) {
                setLoading(true);
                const response = await fetch(`${GlobalVariables.apiBaseUrl}api/${apiEndPoint}`);
                const data = await response.json();
                setAPIResponse(data);
                setLoading(false);
                setCallAPITrigger(false);
                setSelectedSeats([]);
            }
        }
        callAPI();
    }, [callAPITrigger]);

    useEffect(() => {
        const callPersistsBasketData = async () => {
            if (saveBasketTrigger) {
                setLoading(true);

                let basketId = localStorage.getItem('basketid');
                if (!basketId) basketId = createId();
                const myBasket = {
                    id: basketId,
                    items: cartItems
                }
                const options = {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(myBasket)
                };

                const response = await fetch(`${GlobalVariables.apiBaseUrl}api/basket`, options);
                const data = await response.json();
                localStorage.setItem('basketid', data.id);
                setAPIResponse([]);
                setLoading(false);
                setSaveBasketTrigger(false);
            }
        }
        callPersistsBasketData();
    }, [saveBasketTrigger])

    useEffect(() => {        
        const callCheckoutBasket = async () => {
            if (checkoutBasketTrigger) {
                setLoading(true);                                
                const options = {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json;charset=utf-8'
                    },
                    body: JSON.stringify(checkoutObj)
                };

                const response = await fetch(`${GlobalVariables.apiBaseUrl}api/basket/checkout`, options);
                setLoading(false);
                setCheckoutBasketTrigger(false);
            }
        }
        callCheckoutBasket();
    }, [checkoutBasketTrigger])

    const selectedSeatToggle = (rowN, seatN) => {
        setAPIResponse(prev => {
            return {
                rows: prev.rows.map(row => {
                    if (row.rowNumber === rowN) {
                        return {
                            ...row,
                            seats: row.seats.map(seat => {
                                if (seat.seatNumber === seatN) {
                                    return {
                                        ...seat,
                                        isSelected: !seat.isSelected
                                    }
                                }
                                return seat;
                            })
                        };
                    }
                    return row;
                })
            };
        });
    }

    const invokeAPIMethod = (apiEndPoint, hideFooter) => {
        setAPIEndPoint(apiEndPoint);
        setCallAPITrigger(true);
        setHideFooter(hideFooter);
    }

    const storeSelectedMovie = (movie) => {
        setSelectedMovie(movie);
    }

    const getScreeningData = () => {
        setScreeningData(Common.getScreeningData());
    }

    const setDayIsSelected = (data) => {
        setScreeningData(prev => prev.map(item => item.day === data?.day ? { ...item, isSelected: true } : { ...item, isSelected: false }));
        setScreeningShortDate(data?.shortDate);
    }

    const storeScreeningTime = (time) => {
        setScreeningTime(time);
    }

    const showFooter = () => {
        setHideFooter(false);
        setSelectedSeats([]);
    }

    const selectedSeatHandler = (seat, flag) => {
        if (flag) {
            setSelectedSeats(prev => prev.filter(s => s.row !== seat.row || s.number !== seat.number));
        } else {
            setSelectedSeats(prev => [...prev, seat]);
        }
    }

    const addItemToCart = (item) => {
        if (!cartItems.find(cartItem => cartItem.movieId === item.movieId)) {
            setCartItems(prev => [...prev, item]);
            setSaveBasketTrigger(true);
            setSelectedSeats([]);
        }
    }

    const deleteCartItem = (movieId) => {
        setCartItems(prev => prev.filter(item => item.movieId !== movieId));
        setSaveBasketTrigger(true);
    }

    const setCheckoutAPICallParams = (checkoutInfo) => {
        setCheckoutObj(checkoutInfo);
    }

    const checkoutBasket = () => {
        setCheckoutBasketTrigger(true);
    }

    const deleteBasket = () => {
        setCartItems([]);
        localStorage.removeItem('basketid');
    }

    return (
        <MovieContext.Provider value={{
            allMovies,
            cartItems,
            loading,
            selectedMovie,
            screeningData,
            screeningShortDate,
            screeningTime,
            apiResponse,
            hideFooter,
            selectedSeats,
            storeSelectedMovie,
            setDayIsSelected,
            storeScreeningTime,
            invokeAPIMethod,
            selectedSeatToggle,
            showFooter,
            selectedSeatHandler,
            addItemToCart,
            deleteCartItem,
            setCheckoutAPICallParams,
            checkoutBasket,
            deleteBasket
        }}>
            {props.children}
        </MovieContext.Provider>
    )
}

export { MovieContextProvider, MovieContext };