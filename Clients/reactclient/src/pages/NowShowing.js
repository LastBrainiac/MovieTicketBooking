import { useContext, useEffect } from "react";
import { MovieContext } from "../MovieContext";
import Movie from "../components/Movie";

const NowShowing = () => {
    const { allMovies, screeningData, setDayIsSelected } = useContext(MovieContext);

    const nowShowingMovies = allMovies.map(movie => {
        return (
            <Movie key={movie.id} movie={movie} />
        )
    });

    useEffect(() => {
        if (screeningData.length > 0) {
            setDayIsSelected(screeningData[0], 0);
        }        
    }, []);

    return (
        <main className="ns-container">
            <h2>NOW SHOWING</h2>
            <div className="now-showing">
                {nowShowingMovies}
            </div>
        </main>
    )
}

export default NowShowing;