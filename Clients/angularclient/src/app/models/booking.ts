export interface BookingHeader {
    fullName: string;
    emailAddress:string;
    phoneNumber: string;
    bookingDetails: BookingDetails[];
}

export interface BookingDetails {
    movieId: string;
    movieTitle: string;
    ticketQuantity: number;
    ticketPrice: number;
    screeningDate: string;
    reservedSeats: ReservedSeat[];
}

export interface ReservedSeat {
    row: number;
    seat: number;
}