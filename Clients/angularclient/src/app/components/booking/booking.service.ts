import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BookingHeaderDto } from 'src/app/models/booking';
import { ViewingArea } from 'src/app/models/viewingArea';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  baseUrl: string = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  getViewingAreaByMovieAndDate(movieId: string, screeningDate: string) {
    return this.http.get<ViewingArea>(`${this.baseUrl}booking?movieid=${movieId}&screeningdate=${screeningDate}`);
  }

  saveBookingData(booking: BookingHeaderDto) {
    return this.http.post(`${this.baseUrl}booking`, booking);
  }
}
