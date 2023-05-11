
const Movie = ({ movie }) => {

    return (
        <div className="movie-card">
            <img className="movie-img" src={`data:image/jpg;base64,${movie.thumbnailPic}`} alt={movie.title} />
            <div className="masked">
                <p className="movie-title">{movie.title.toUpperCase()}</p>
                <p className="movie-genre">{movie.genre}</p>
                <p className="movie-release-year">{movie.releaseYear}</p>
                <p className="movie-length">Length {movie.movieLength}</p>
                <button className="btn btn-booking">Ticket Booking</button>
            </div>
        </div>
    )
}

export default Movie;