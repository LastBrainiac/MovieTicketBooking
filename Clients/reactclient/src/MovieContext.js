import { createContext, useEffect, useState } from 'react';
import * as GlobalVariables from './shared/globals.js';

const MovieContext = createContext();

const MovieContextProvider = (props) => {
    const [allMovies, setAllMovies] = useState([]);
    const [cartItems, setCartItems] = useState([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        setLoading(true);
        const getMovies = async () => {
            const response = await fetch(`${GlobalVariables.baseUrl}api/movies`);
            const data = await response.json();
            setAllMovies(data);
            setLoading(false);
        }
        getMovies();
    }, []);

    return (
        <MovieContext.Provider value={{
            allMovies,
            cartItems,
            loading
        }}>            
            {props.children}
        </MovieContext.Provider>
    )
}

export { MovieContextProvider, MovieContext };