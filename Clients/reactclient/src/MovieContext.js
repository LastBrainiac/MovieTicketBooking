import { createContext, useEffect, useState } from 'react';
import * as GlobalVariables from './shared/globals.js';
import * as Common from './shared/common.js';

const MovieContext = createContext();

const MovieContextProvider = (props) => {
    const [allMovies, setAllMovies] = useState([]);
    const [cartItems, setCartItems] = useState([]);
    const [loading, setLoading] = useState(false);
    const [selectedMovie, setSelectedMovie] = useState({});
    const [screeningData, setScreeningData] = useState([]);
    const [screeningShortDate, setScreeningShortDate] = useState('');
    const [screeningTime, setScreeningTime] = useState('');

    useEffect(() => {
        setLoading(true);
        const getMovies = async () => {
            const response = await fetch(`${GlobalVariables.baseUrl}api/movies`);
            const data = await response.json();
            setAllMovies(data);
            setLoading(false);
        }
        getMovies();
        getScreeningData();
    }, []);

    const storeSelectedMovie = (movie) => {
        setSelectedMovie(movie);
    }

    const getScreeningData = () => {
        setScreeningData(Common.getScreeningData());
    }

    const setDayIsSelected = (data) => {
        setScreeningData(prev => prev.map(item => item.day === data.day ? { ...item, isSelected: true } : { ...item, isSelected: false }));
        setScreeningShortDate(data.shortDate);
    }

    const storeScreeningTime = (time) => {
        setScreeningTime(time);
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
            storeSelectedMovie,
            setDayIsSelected,
            storeScreeningTime
        }}>
            {props.children}
        </MovieContext.Provider>
    )
}

export { MovieContextProvider, MovieContext };