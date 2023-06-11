import { Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  requestCount = 0;

  constructor(private spinnerSvc: NgxSpinnerService) { }

  start() {
    this.requestCount++;
    this.spinnerSvc.show(undefined, {
      type: 'ball-spin-clockwise',
      bdColor: 'rgba(0,0,0,0.7)',
      color: '#bbb'
    })
  }

  stop() {
    this.requestCount--;
    if (this.requestCount <= 0) {
      this.requestCount = 0;
      this.spinnerSvc.hide();
    }
  }
}
