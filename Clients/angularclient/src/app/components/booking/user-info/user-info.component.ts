import { AfterViewInit, Component, ElementRef, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookingHeaderDto } from 'src/app/models/booking';
import { BookingService } from '../booking.service';
import { environment } from 'src/environments/environment';
import { Helper } from 'src/app/core/helper';

@Component({
  selector: 'app-user-info',
  templateUrl: './user-info.component.html',
  styleUrls: ['./user-info.component.scss']
})
export class UserInfoComponent implements AfterViewInit {
  @ViewChild('fullName') fullNameField?: ElementRef<HTMLInputElement>;

  bookingData: any;
  selectedDate: any;
  ticketPrice: any;

  constructor(private router: Router,
    private toastr: ToastrService,
    private fb: FormBuilder,
    private bookingSvc: BookingService) {
    this.bookingData = this.router.getCurrentNavigation()?.extras.state;
    this.selectedDate = Helper.getLongDateShortTime().format(new Date(this.bookingData.screeningDate));
    this.ticketPrice = environment.ticketPrice;
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      this.fullNameField?.nativeElement.focus();
    });
  }

  userInfoForm = this.fb.group({
    fullName: [null, Validators.required],
    emailAddress: [null, [Validators.required, Validators.email]],
    phoneNumber: null
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
          ticketPrice: this.ticketPrice,
          screeningDate: new Date(this.bookingData.screeningDate).toISOString(),
          reservedSeats: this.bookingData.bookedSeats
        }
      ]
    }
  }
}
