import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { SelectedSeat } from 'src/app/models/selectedSeat';
import { SeatSelectionComponent } from '../seat-selection/seat-selection.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {
  seatList: any;

  constructor(private router: Router) { 
    console.log(this.router.getCurrentNavigation()?.extras.state)
  }

}
