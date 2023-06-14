import { Component, Input, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie';
import { ScreeningData } from 'src/app/models/screeningData';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.scss']
})
export class MovieDetailsComponent implements OnInit {
  @Input() movie?: Movie;
  @Input() item?: ScreeningData;

  ngOnInit(): void {
    
  }

}
