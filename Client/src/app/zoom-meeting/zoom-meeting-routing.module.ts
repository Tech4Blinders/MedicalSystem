import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { DoctorMeetingComponent } from './doctor-meeting/doctor-meeting.component';
import { PatientMeetingComponent } from './patient-meeting/patient-meeting.component';
import { MeetingComponent } from './meeting/meeting.component';
import { StartMeetingComponent } from './start-meeting/start-meeting.component';
import { JoinMeetingComponent } from './join-meeting/join-meeting.component';

const routes: Routes = [
  { path: '', component: MeetingComponent },
  { path: 'doctor', component: DoctorMeetingComponent },
  { path: 'patient', component: PatientMeetingComponent },
  { path: 'startmeeting', component: StartMeetingComponent },
  { path: 'joinmeeting', component: JoinMeetingComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ZoomMeetingRoutingModule { }
