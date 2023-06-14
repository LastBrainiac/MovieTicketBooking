import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-seat-selection',
  templateUrl: './seat-selection.component.html',
  styleUrls: ['./seat-selection.component.scss']
})
export class SeatSelectionComponent implements OnInit {
  movieId?: string;
  screeningDate?: string;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(
      params => {
        this.movieId = params['movieId'];
        this.screeningDate = params['screeningDate'].join(' ')
      }
    )

    console.log(this.movieId)
    console.log(this.screeningDate)
  }
}
