import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClinicRoutingModule } from './clinic-routing.module';
import { ClinicHomeComponent } from './clinic-home/clinic-home.component';
import { SlideClincComponent } from './slide-clinc/slide-clinc.component';
import { GalleriaModule } from 'primeng/galleria';
import { DoctorCardComponent } from './doctor-card/doctor-card.component';
import { CardModule } from 'primeng/card';
import { RatingModule } from 'primeng/rating';


@NgModule({
  declarations: [
    ClinicHomeComponent,
    SlideClincComponent,
    DoctorCardComponent
  ],
  imports: [
    CommonModule,
    ClinicRoutingModule,GalleriaModule,CardModule ,RatingModule
  ]
})
export class ClinicModule { }
