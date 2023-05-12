import { useState } from "react";
import { Link } from "react-router-dom";

const Movie = ({ movie }) => {
    const [data, setData] = useState(movie);

    return (
        <div className="movie-card">
            <img className="movie-img" src={`data:image/jpg;base64,${movie.thumbnailPic}`} alt={movie.title} />
            <div className="masked">
                <p className="movie-title">{movie.title.toUpperCase()}</p>
                <p className="movie-genre">{movie.genre}</p>
                <p className="movie-release-year">{movie.releaseYear}</p>
                <p className="movie-length">Length {movie.movieLength}</p>
                <Link to='/screening' state={{ movie: data }} className="btn btn-booking"><p>Ticket Booking</p></Link>
            </div>
        </div>
    )
}

export default Movie;