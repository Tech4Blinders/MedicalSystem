import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { DoctorMeetingComponent } from './doctor-meeting/doctor-meeting.component';
import { PatientMeetingComponent } from './patient-meeting/patient-meeting.component';
import { MeetingComponent } from './meeting/meeting.component';
import { StartMeetingComponent } from './start-meeting/start-meeting.component';
import { JoinMeetingComponent } from './join-meeting/join-meeting.component';
import { DoctorGuardGuard } from '../doctor-guard.guard';
import { PatientGuardGuard } from '../patient-guard.guard';

const routes: Routes = [
  { path: '', component: MeetingComponent,canActivate:[DoctorGuardGuard] },
  { path: 'doctor', component: DoctorMeetingComponent,canActivate:[DoctorGuardGuard] },
  { path: 'patient', component: PatientMeetingComponent,canActivate:[PatientGuardGuard] },
  { path: 'startmeeting', component: StartMeetingComponent,canActivate:[DoctorGuardGuard] },
  { path: 'joinmeeting', component: JoinMeetingComponent,canActivate:[PatientGuardGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ZoomMeetingRoutingModule { }
