import { createContext, useEffect, useState } from 'react';
import * as GlobalVariables from './shared/globals.js';


const MovieContext = createContext();

const MovieContextProvider = (props) => {
    const [allMovies, setAllMovies] = useState([]);
    const [cartItems, setCartItems] = useState([]);

    useEffect(() => {
        async function getMovies() {
            const response = await fetch(`${GlobalVariables.baseUrl}api/movies`);
            const data = await response.json();
            setAllMovies(data);
        }
        getMovies();
    }, []);

    return (
        <MovieContext.Provider value={{
            allMovies,
            cartItems
        }}>
            {props.children}
        </MovieContext.Provider>
    )
}

export { MovieContextProvider, MovieContext };