import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { Movie } from 'src/app/models/movie';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class CinemaService {
  baseUrl: string = environment.apiBaseUrl;
  private moviesSource = new BehaviorSubject<Movie[] | null>(null);
  movieSource$ = this.moviesSource.asObservable();

  constructor(private http: HttpClient) { }

  getMovieList() {
    return this.http.get<Movie[]>(`${this.baseUrl}movies`).pipe(
      map(movieList => {
        this.moviesSource.next(movieList)
      })
    );
  }

}
