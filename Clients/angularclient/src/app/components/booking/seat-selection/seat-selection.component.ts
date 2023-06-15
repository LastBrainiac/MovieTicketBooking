import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SeatSelectionService } from './seat-selection.service';
import { ViewingArea } from 'src/app/models/viewingArea';
import { CinemaService } from '../../home/cinema.service';
import { Movie } from 'src/app/models/movie';
import { SelectedSeat } from 'src/app/models/selectedSeat';

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.scss']
})
export class SeatSelectionComponent implements OnInit {
  movieId?: string;
  screeningDate?: string;
  viewingArea?: ViewingArea;
  selectedMovie?: Movie;
  selectedSeats?: SelectedSeat[] = [];

  constructor(private route: ActivatedRoute,
    private seatSvc: SeatSelectionService,
    private cinemaSvc: CinemaService) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        this.movieId = params['movieId'];
        this.screeningDate = params['screeningDate'].join(' ')
      }
    )

    this.seatSvc.getViewingAreaByMovieAndDate(this.movieId!, new Date(this.screeningDate!).toISOString())
      .subscribe({
        next: resp => this.viewingArea = resp,
        error: err => console.log(err)
      });

    this.cinemaSvc.movieSource$.subscribe(
      movieList => this.selectedMovie = movieList?.find(movie => movie.id === this.movieId)
    )
  }

  onSeatClicked(seat: SelectedSeat, isBooked: boolean, isSelected: boolean) {
    if (!isBooked) {
      if (!isSelected) {
        if (!this.selectedSeats?.find(s => s.row === seat.row && s.number === seat.number)) this.selectedSeats?.push(seat);
      } else {
        if (this.selectedSeats?.find(s => s.row === seat.row && s.number === seat.number)) {
          let index = this.selectedSeats.findIndex(s => s.row === seat.row && s.number === seat.number);
          this.selectedSeats.splice(index, 1);
        }
      }
      this.viewingArea = this.getViewingArea(seat);
    }
    console.log(this.selectedSeats)
    // console.log(this.viewingArea)
  }

  private getViewingArea(seat: SelectedSeat): ViewingArea {
    return {
      rows: this.viewingArea?.rows?.map(row => {
        if (row.rowNumber === seat.row) {
          return {
            ...row,
            seats: row.seats.map(s => {
              if (s.seatNumber === seat.number) {
                return {
                  ...s,
                  isSelected: !s.isSelected
                }
              }
              return s;
            })
          }
        }
        return row;
      })
    }
  }

}
