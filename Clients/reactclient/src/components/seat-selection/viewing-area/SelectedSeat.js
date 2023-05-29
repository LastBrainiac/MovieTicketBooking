const SelectedSeat = ({ row, number }) => {
    return (
        <div className="selected-seat">
            <p>{row}/{number}</p>
        </div>
    )
}

export default SelectedSeat;