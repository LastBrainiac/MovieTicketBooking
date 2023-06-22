import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookingHeaderDto } from 'src/app/models/booking';
import { BookingService } from '../booking.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent {
  bookingData: any;

  constructor(private router: Router,
    private toastr: ToastrService,
    private fb: FormBuilder,
    private bookingSvc: BookingService) {
    this.bookingData = this.router.getCurrentNavigation()?.extras.state;
  }

  userInfoForm = this.fb.group({
    fullName: ['', Validators.required],
    emailAddress: ['', [Validators.required, Validators.email]],
    phoneNumber: ''
  });

  onSubmit() {
    this.bookingSvc.saveBookingData(this.getRequestDto()).subscribe({
      next: () => {
        this.toastr.success('Your ticket booking was successful! The notification email has been sent.');
        this.router.navigate(['/booking']);
      },
      error: err => {
        this.toastr.error(err.message);
        console.log(err)
      }
    })
  }

  getRequestDto(): BookingHeaderDto {
    return {
      fullName: this.userInfoForm.get('fullName')?.value!,
      emailAddress: this.userInfoForm.get('emailAddress')?.value!,
      phoneNumber: this.userInfoForm.get('phoneNumber')?.value!,
      bookingDetails: [
        {
          movieId: this.bookingData.selectedMovie.id,
          movieTitle: this.bookingData.selectedMovie.title,
          ticketQuantity: this.bookingData.bookedSeats.length,
          ticketPrice: environment.ticketPrice,
          screeningDate: new Date(this.bookingData.screeningDate).toISOString(),
          reservedSeats: this.bookingData.bookedSeats
        }
      ]
    }
  }
}
