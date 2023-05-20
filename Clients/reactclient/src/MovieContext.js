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

    const getScreeningData = () => {
        var weekDays = [];

        weekDays = [...Array(7).keys()]
            .map(item => {
                const currentDay = () => {
                    const currentDate = new Date();
                    currentDate.setDate(currentDate.getDate() + item);
                    return currentDate;
                }
                return (
                    {
                        fullDate: currentDay().toLocaleDateString('en-US', { year: 'numeric', month: 'numeric', day: 'numeric' }),
                        day: currentDay().toLocaleDateString('en-US', { day: 'numeric' }),
                        dayName: currentDay().toLocaleDateString('en-US', { weekday: 'short' }),
                        isSelected: item === 0 ? true : false
                    }
                )
            });
        return weekDays;
    }

    return (
        <MovieContext.Provider value={{
            allMovies,
            cartItems,
            loading,
            getScreeningData
        }}>
            {props.children}
        </MovieContext.Provider>
    )
}

export { MovieContextProvider, MovieContext };