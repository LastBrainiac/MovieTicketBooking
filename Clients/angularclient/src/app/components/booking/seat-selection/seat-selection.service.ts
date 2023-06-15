import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ViewingArea } from 'src/app/models/viewingArea';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SeatSelectionService {
  baseUrl: string = environment.apiBaseUrl;

  constructor(private http: HttpClient) { }

  getViewingAreaByMovieAndDate(movieId: string, screeningDate: string) {
    return this.http.get<ViewingArea>(`${this.baseUrl}booking?movieid=${movieId}&screeningdate=${screeningDate}`);
  }
}
