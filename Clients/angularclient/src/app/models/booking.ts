export interface BookingHeaderDto {
    fullName: string;
    emailAddress:string;
    phoneNumber: string;
    bookingDetails: BookingDetailsDto[];
}

export interface BookingDetailsDto {
    movieId: string;
    movieTitle: string;
    ticketQuantity: number;
    ticketPrice: number;
    screeningDate: string;
    reservedSeats: ReservedSeatDto[];
}

export interface ReservedSeatDto {
    row: number;
    seat: number;
}