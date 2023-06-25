import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientComponent } from './patient/patient.component';
import { LoginComponent } from './login/login.component';
import { RegisterationComponent } from './registeration/registeration.component';
import { DoctorComponent } from './doctor/doctor.component';
import { HospitalComponent } from './hospital/hospital.component';

const routes: Routes = [
  {
    path: '',
    component: RegisterationComponent,
    children: [
      { path: '', component: PatientComponent },
      { path: 'doctor', component: DoctorComponent },
      { path: 'admin', component: HospitalComponent },
    ],
  },
  { path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthenticatorRoutingModule {}
