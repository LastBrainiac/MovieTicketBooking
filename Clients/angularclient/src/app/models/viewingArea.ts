export interface ViewingArea {
    rows: Array<Row> | undefined;
}

export interface Row {
    rowNumber: number;
    seats: Array<Seat>;
}

export interface Seat {
    seatNumber: number;
    booked: boolean;
    isSelected: boolean;
}