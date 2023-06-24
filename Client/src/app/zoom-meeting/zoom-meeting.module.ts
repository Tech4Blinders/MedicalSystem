import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DoctorMeetingComponent } from './doctor-meeting/doctor-meeting.component';
import { PatientMeetingComponent } from './patient-meeting/patient-meeting.component';
import { ZoomMeetingRoutingModule } from './zoom-meeting-routing.module';
import { MeetingComponent } from './meeting/meeting.component';
import { TableModule } from 'primeng/table';
import { StartMeetingComponent } from "./start-meeting/start-meeting.component";
import { JoinMeetingComponent } from './join-meeting/join-meeting.component';

@NgModule({
    declarations: [
        DoctorMeetingComponent,
        PatientMeetingComponent,
        MeetingComponent,
        StartMeetingComponent,
        JoinMeetingComponent
    ],
    exports: [
      
    ],
    imports: [
        CommonModule,
        ZoomMeetingRoutingModule,
        TableModule
        
    ]
})
export class ZoomMeetingModule { }
