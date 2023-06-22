import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { BookingComponent } from './booking/booking.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { SharedModule } from '../shared/shared.module';
import { TabcontentComponent } from './booking/tabcontent/tabcontent.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MovieDetailsComponent } from './booking/tabcontent/movie-details/movie-details.component';
import { SeatSelectionComponent } from './booking/seat-selection/seat-selection.component';
import { UserInfoComponent } from './booking/user-info/user-info.component';
import { ComponentsRoutingModule } from './components-routing.module';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button'
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [
    HomeComponent,
    BookingComponent,
    TabcontentComponent,
    MovieDetailsComponent,
    SeatSelectionComponent,
    UserInfoComponent
  ],
  imports: [
    CommonModule,
    CarouselModule,
    SharedModule,
    MatTabsModule,
    ComponentsRoutingModule,
    MatDividerModule,
    MatIconModule,
    MatTooltipModule,
    MatDialogModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ToastrModule.forRoot({
      positionClass: "toast-top-right"
    }),
    FormsModule,
    ReactiveFormsModule
  ]
})
export class ComponentsModule { }
