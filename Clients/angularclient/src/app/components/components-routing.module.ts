import { RouterModule, Routes } from "@angular/router";
import { BookingComponent } from "./booking/booking.component";
import { SeatSelectionComponent } from "./booking/seat-selection/seat-selection.component";
import { UserInfoComponent } from "./booking/user-info/user-info.component";
import { NgModule } from "@angular/core";

const routes: Routes = [
    { path: '', component: BookingComponent, },
    { path: 'selectseat', component: SeatSelectionComponent },
    { path: 'userinfo', component: UserInfoComponent },
]

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class ComponentsRoutingModule { }