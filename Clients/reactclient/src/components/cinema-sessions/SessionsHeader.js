const SessionHeader = ({ movie }) => {
    return (
        <div className="session-header">
            <div className="bkg-mask">
                <img className="session-background" src={`data:image/jpg;base64,${movie.thumbnailPic}`} alt={movie.title} />
            </div>
            <div className="session-title">
                <img className="title-img" src={`data:image/jpg;base64,${movie.thumbnailPic}`} alt={movie.title} />
                <div className="title-content">
                    <p className="title">{movie.title.toUpperCase()}</p>
                    <p className="title-other">{movie.movieLength} | {movie.releaseYear} | {movie.genre}</p>
                </div>
            </div>
        </div>
    )
}

export default SessionHeader;

