import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MeetingRoutingModule } from './meeting-routing.module';
import { PatientmeetingComponent } from './patientmeeting/patientmeeting.component';
import { DoctormeetingComponent } from './doctormeeting/doctormeeting.component';
import { TableModule } from 'primeng/table';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';


@NgModule({
  declarations: [
    PatientmeetingComponent,
    DoctormeetingComponent
  ],
  imports: [
    CommonModule,
    MeetingRoutingModule,
    TableModule,
    FormsModule,
    ButtonModule
  ]
})
export class MeetingModule { }
