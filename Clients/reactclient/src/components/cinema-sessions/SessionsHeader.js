import { useContext, useEffect } from "react";
import { MovieContext } from "../../MovieContext";

const SessionHeader = () => {
    const { selectedMovie, setDayIsSelected, screeningData } = useContext(MovieContext);

    var item = (screeningData.find(item => item.isSelected));

    useEffect(() => {
        setDayIsSelected(item === undefined ? screeningData[0] : item);
    }, []);

    return (
        <div className="session-header">
            <div className="bkg-mask">
                <img className="session-background" src={`data:image/jpg;base64,${selectedMovie.thumbnailPic}`} alt={selectedMovie.title} />
            </div>
            <div className="session-title">
                <img className="title-img" src={`data:image/jpg;base64,${selectedMovie.thumbnailPic}`} alt={selectedMovie.title} />
                <div className="title-content">
                    <p className="title">{selectedMovie.title.toUpperCase()}</p>
                    <p className="title-other">{selectedMovie.movieLength} | {selectedMovie.releaseYear} | {selectedMovie.genre}</p>
                </div>
            </div>
        </div>

    )
}

export default SessionHeader;

