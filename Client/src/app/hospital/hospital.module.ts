import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardModule } from 'primeng/card';

import { HospitalComponent } from './hospital.component';
import { HoSection2Component } from './hosection2/hosection2.component';
import { HospitalRoutingModule } from './hospital-routing.module';
import { Hosection1Component } from './hosection1/hosection1.component';
import { Section6Component } from './section6/section6.component';
import { CardSectionComponent } from './card-section/card-section.component';
import { AppointmentComponent } from './appointment/appointment.component';

@NgModule({
  declarations: [HospitalComponent, HoSection2Component, Hosection1Component, Section6Component, CardSectionComponent, AppointmentComponent,
  ],
  imports: [CommonModule, HospitalRoutingModule,CardModule],
  exports: [HoSection2Component, Hosection1Component, Section6Component,AppointmentComponent],
})
export class HospitalModule {}
