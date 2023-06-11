import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { BookingComponent } from './booking/booking.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    HomeComponent,
    BookingComponent
  ],
  imports: [
    CommonModule,
    CarouselModule,
    SharedModule
  ],
  exports: [
    HomeComponent,
    BookingComponent
  ]
})
export class ComponentsModule { }
