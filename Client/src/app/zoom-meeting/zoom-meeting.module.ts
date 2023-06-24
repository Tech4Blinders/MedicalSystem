import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorMeetingComponent } from './doctor-meeting/doctor-meeting.component';
import { PatientMeetingComponent } from './patient-meeting/patient-meeting.component';
import { ZoomMeetingRoutingModule } from './zoom-meeting-routing.module';
import { MeetingComponent } from './meeting/meeting.component';
import { StartMeetingComponent } from './start-meeting/start-meeting.component';
import { JoinMeetingComponent } from './join-meeting/join-meeting.component';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    DoctorMeetingComponent,
    PatientMeetingComponent,
    MeetingComponent,
    StartMeetingComponent,
    JoinMeetingComponent
  ],
  imports: [
    CommonModule,
    ZoomMeetingRoutingModule,
    TableModule,
  ],
  exports:[
    DoctorMeetingComponent,
    PatientMeetingComponent,
    MeetingComponent,
    StartMeetingComponent,
    JoinMeetingComponent,
  
  ]
})
export class ZoomMeetingModule { }
