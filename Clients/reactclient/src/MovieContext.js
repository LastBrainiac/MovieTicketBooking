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

    return (
        <MovieContext.Provider value={{
            allMovies,
            cartItems,
            loading,
            selectedMovie,
            screeningData,
            storeSelectedMovie
        }}>
            {props.children}
        </MovieContext.Provider>
    )
}

export { MovieContextProvider, MovieContext };