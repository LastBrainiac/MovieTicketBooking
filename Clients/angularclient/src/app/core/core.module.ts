import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NavBarComponent } from './nav-bar/nav-bar.component';

@NgModule({
  declarations: [
    NavBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    NgxSpinnerModule
  ],
  exports: [
    NavBarComponent,
    NgxSpinnerModule
  ]
})
export class CoreModule { }
