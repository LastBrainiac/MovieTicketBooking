import { createContext, useEffect, useState } from 'react';
import * as GlobalVariables from './shared/globals.js';


const MovieContext = createContext();

const MovieContextProvider = (props) => {
    const [allMovies, setAllMovies] = useState([]);

    useEffect(() => {
        fetch(`${GlobalVariables.baseUrl}api/movies`)
            .then(resp => resp.json())
            .then(data => {
                setAllMovies(data);
                console.log(data);
            });
    }, []);

    return (
        <MovieContext.Provider value={{
            allMovies
        }}>
            {props.children}
        </MovieContext.Provider>
    )
}

export { MovieContextProvider, MovieContext };