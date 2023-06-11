import { Component, OnInit } from '@angular/core';
import { CinemaService } from './components/home/cinema.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Movie Ticket Booking';

  constructor(private cinemaSvc: CinemaService) {}

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies() {
    this.cinemaSvc.getMovieList().subscribe();
  }
}
