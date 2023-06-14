import { Component, OnInit } from '@angular/core';
import { Helper } from 'src/app/core/helper';
import { ScreeningData } from 'src/app/models/screeningData';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit {
  screeningData: ScreeningData[] = [];
  
  constructor() { }

  ngOnInit(): void {
    this.screeningData = Helper.getScreeningData();
  }


}
