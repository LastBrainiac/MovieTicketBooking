export interface ViewingArea {
    rows: Row[] | undefined;
}

export interface Row {
    rowNumber: number;
    seats: Seat[];
}

export interface Seat {
    seatNumber: number;
    booked: boolean;
    isSelected: boolean;
}