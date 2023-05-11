import { useContext } from "react"
import { MovieContext } from "../MovieContext"
import Movie from "../components/Movie";

const NowShowing = () => {
    const { allMovies } = useContext(MovieContext);

    const nowShowingMovies = allMovies.map(movie => {
        return (
            <Movie key={movie.id} movie={movie} />
        )
    });

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