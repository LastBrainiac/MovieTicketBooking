import { Component, OnInit } from '@angular/core';
import { CinemaService } from './cinema.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(public cinemaSvc: CinemaService) { }

  ngOnInit(): void {

  }

}
