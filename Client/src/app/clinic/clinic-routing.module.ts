import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicHomeComponent } from './clinic-home/clinic-home.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { MeetingComponent } from './meeting/meeting.component';

const routes: Routes = [{path:"",component:ClinicHomeComponent},{path:"appointment",component:AppointmentComponent},
{path:"meeting",component:MeetingComponent}];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClinicRoutingModule { }
