export interface BookingHeaderDto {
    fullName: string;
    emailAddress:string;
    phoneNumber: string;
    bookingDetails: Array<BookingDetailsDto>;
}

export interface BookingDetailsDto {
    movieId: string;
    movieTitle: string;
    ticketQuantity: number;
    ticketPrice: number;
    screeningDate: string;
    reservedSeats: Array<ReservedSeatDto>;
}

export interface ReservedSeatDto {
    row: number;
    seat: number;
}