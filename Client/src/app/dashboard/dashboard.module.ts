import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddDoctorComponent } from './add-doctor/add-doctor.component';
import { UpdateDoctorComponent } from './update-doctor/update-doctor.component';
import { AllDoctorsComponent } from './all-doctors/all-doctors.component';


@NgModule({
  declarations: [
    DashboardHomeComponent,
    AddDoctorComponent,
    UpdateDoctorComponent,
    AllDoctorsComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ReactiveFormsModule
  ],
  exports: [
    DashboardHomeComponent
  ]
})
export class DashboardModule { }
