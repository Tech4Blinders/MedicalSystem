import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClinicRoutingModule } from './clinic-routing.module';
import { ClinicHomeComponent } from './clinic-home/clinic-home.component';
import { SlideClincComponent } from './slide-clinc/slide-clinc.component';
import { GalleriaModule } from 'primeng/galleria';
import { DoctorCardComponent } from './doctor-card/doctor-card.component';
import { CardModule } from 'primeng/card';
import { RatingModule } from 'primeng/rating';
import { AppointmentComponent } from './appointment/appointment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MeetingComponent } from './meeting/meeting.component';
import { PaymentComponent } from './payment/payment.component';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';


@NgModule({
  declarations: [
    ClinicHomeComponent,
    SlideClincComponent,
    DoctorCardComponent,
    AppointmentComponent,
    MeetingComponent,
    PaymentComponent
  ],
  imports: [
    CommonModule,
    ClinicRoutingModule,GalleriaModule,CardModule ,RatingModule,FormsModule,ReactiveFormsModule,ToggleButtonModule,DialogModule,ButtonModule
  ]
})
export class ClinicModule { }
