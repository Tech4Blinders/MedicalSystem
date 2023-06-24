import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicHomeComponent } from './clinic-home/clinic-home.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { MeetingComponent } from './meeting/meeting.component';
import { PaymentComponent } from './payment/payment.component';

const routes: Routes = [{path:"",component:ClinicHomeComponent},{path:"appointment",component:AppointmentComponent},
{path:"meeting",component:MeetingComponent},
{path:"appointment/payment",component:PaymentComponent}];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClinicRoutingModule { }
