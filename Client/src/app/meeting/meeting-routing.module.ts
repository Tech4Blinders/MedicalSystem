import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientmeetingComponent } from './patientmeeting/patientmeeting.component';
import { DoctormeetingComponent } from './doctormeeting/doctormeeting.component';
import { PatientGuardGuard } from '../patient-guard.guard';
import { DoctorGuardGuard } from '../doctor-guard.guard';

const routes: Routes = [{path:'',component:PatientmeetingComponent,canActivate:[PatientGuardGuard]},
{path:"mymeeting",component:DoctormeetingComponent,canActivate:[DoctorGuardGuard]}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingRoutingModule { }
