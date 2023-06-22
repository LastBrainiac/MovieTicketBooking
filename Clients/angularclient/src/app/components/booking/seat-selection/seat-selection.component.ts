import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { ActivatedRoute, NavigationExtras, Router } from '@angular/router';
import { ViewingArea } from 'src/app/models/viewingArea';
import { CinemaService } from '../../home/cinema.service';
import { Movie } from 'src/app/models/movie';
import { SelectedSeat } from 'src/app/models/selectedSeat';
import { BookingService } from '../booking.service';
import { environment } from 'src/environments/environment';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.scss']
})
export class SeatSelectionComponent implements OnInit {
  @ViewChild('template', { static: true }) modalWindow?: TemplateRef<any>;

  movieId?: string;
  screeningDate?: string;
  viewingArea?: ViewingArea;
  selectedMovie?: Movie;
  selectedSeats?: SelectedSeat[] = [];

  constructor(private route: ActivatedRoute,
    private bookingSvc: BookingService,
    private cinemaSvc: CinemaService,
    private routing: Router,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        this.movieId = params['movieId'];
        this.screeningDate = params['screeningDate'].join(' ');
      }
    )

    this.bookingSvc.getViewingAreaByMovieAndDate(this.movieId!, new Date(this.screeningDate!).toISOString())
      .subscribe({
        next: resp => this.viewingArea = resp,
        error: err => console.log(err)
      });

    this.cinemaSvc.movieSource$.subscribe(
      movieList => this.selectedMovie = movieList?.find(movie => movie.id === this.movieId)
    )
  }

  showNotification() {
    this.dialog.open(this.modalWindow!);
  }

  onButtonClicked() {
    const navExtras: NavigationExtras = {
      state: {
        bookedSeats: this.selectedSeats,
        selectedMovie: this.selectedMovie,
        screeningDate: this.screeningDate
      }
    };
    this.routing.navigate(['/booking/userinfo'], navExtras);
  }

  onSeatClicked(seat: SelectedSeat, isBooked: boolean, isSelected: boolean) {
    let ticketCountReachedMaxValue = false;
    if (!isBooked) {
      if (!isSelected) {
        if (this.selectedSeats?.length! < environment.maxTicketCount) {
          if (!this.selectedSeats?.find(s => s.row === seat.row && s.seat === seat.seat)) this.selectedSeats?.push(seat);
        } else {
          ticketCountReachedMaxValue = true;
          this.showNotification();
        }
      } else {
        const index: any = this.selectedSeats?.findIndex(s => s.row === seat.row && s.seat === seat.seat);
        this.selectedSeats?.splice(index, 1);
      }
      if (!ticketCountReachedMaxValue) {
        this.viewingArea = this.getViewingArea(seat);
      }
    }
  }

  private getViewingArea(seat: SelectedSeat): ViewingArea {
    return {
      rows: this.viewingArea?.rows?.map(row => {
        if (row.rowNumber === seat.row) {
          return {
            ...row,
            seats: row.seats.map(s => {
              if (s.seatNumber === seat.seat) {
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
