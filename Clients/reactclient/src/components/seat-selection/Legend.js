const Legend = () => {
    return (
        <div className="legend">
            <div className="legend-item">
                <div className="square legend-square-available"></div>
                <p className="legend-title">Available</p>
            </div>
            <div className="legend-item">
                <div className="square square-unavailable"></div>
                <p className="legend-title">Booked</p>
            </div>
            <div className="legend-item">
                <div className="square square-selected nope"></div>
                <p className="legend-title">Selected</p>
            </div>
        </div>
    )
}

export default Legend;