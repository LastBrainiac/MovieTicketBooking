import { Component, Input, OnInit } from '@angular/core';
import { ScreeningData } from 'src/app/models/screeningData';
import { CinemaService } from '../../home/cinema.service';
import { Movie } from 'src/app/models/movie';
import { Helper } from 'src/app/core/helper';

@Component({
  selector: 'app-tabcontent',
  templateUrl: './tabcontent.component.html',
  styleUrls: ['./tabcontent.component.scss']
})
export class TabcontentComponent implements OnInit {
  @Input() item?: ScreeningData;
  movieList: Movie[] | null = [];
  selectedDate: any;

  constructor(private cinemaSvc: CinemaService) { }

  ngOnInit(): void {
    this.cinemaSvc.movieSource$.subscribe(
      movies => this.movieList = movies
    )

    this.selectedDate = Helper.getLongDate().format(new Date(this.item?.shortDate!))
  }

}
