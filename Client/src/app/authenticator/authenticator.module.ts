import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticatorRoutingModule } from './authenticator-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { SelectButtonModule } from 'primeng/selectbutton';
import { PatientComponent } from './patient/patient.component';
import { RegisterationComponent } from './registeration/registeration.component';
import { LoginComponent } from './login/login.component';
import { DoctorComponent } from './doctor/doctor.component';
import { HospitalComponent } from './hospital/hospital.component';


@NgModule({
  declarations: [
    PatientComponent,
    RegisterationComponent,
    LoginComponent,
    DoctorComponent,
    HospitalComponent
  ],
  imports: [
    CommonModule,
    AuthenticatorRoutingModule,
    ReactiveFormsModule,
    HttpClientModule ,
    FormsModule ,
    RouterModule,
    DialogModule,
    ButtonModule,
    SelectButtonModule
  ]
})
export class AuthenticatorModule { }
