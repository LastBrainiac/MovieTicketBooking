import Seat from "./Seat";

const Row = ({ rowNumber, seats }) => {
    const rowSeats = seats?.map((seat, index) => {
        return (
            <Seat key={index} seat={seat} row={rowNumber} />
        )
    })

    return (
        <div className='row'>
            <div className="row-number">{rowNumber}.</div>
            <div className="row-seats">{rowSeats}</div>
        </div>
    )
}

export default Row;