import { useContext } from "react";
import { MovieContext } from "../../MovieContext";

const SelectionHeader = () => {
    const { selectedMovie, screeningShortDate, screeningTime } = useContext(MovieContext);
    return (
        <div className="selection-header">
            <div className="selection-bkg-mask">
                <img className="selection-background" src={`data:image/jpg;base64,${selectedMovie?.thumbnailPic}`} alt={selectedMovie?.title} />
            </div>
            <div className="selection-title">
                <img className="selection-title-img" src={`data:image/jpg;base64,${selectedMovie?.thumbnailPic}`} alt={selectedMovie?.title} />
                <div className="title-content selection-title-content">
                    <p className="title">{selectedMovie?.title?.toUpperCase()}</p>
                    <p className="title-other">{selectedMovie?.movieLength} | {selectedMovie?.releaseYear} | {selectedMovie?.genre}</p>
                    <p className="title-other">{screeningShortDate} {screeningTime}</p>
                </div>
            </div>
        </div>
    )
}

export default SelectionHeader;