import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HospitalComponent } from './hospital.component';
import { AppointmentComponent } from './appointment/appointment.component';

const routes: Routes = [
  { path: '', component: HospitalComponent },
  {path:"appointment",component:AppointmentComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HospitalRoutingModule {}
