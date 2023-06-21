import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardHomeComponent } from './dashboard-home/dashboard-home.component';
import { UpdateDoctorComponent } from './update-doctor/update-doctor.component';

const routes: Routes = [
  {path:"", component:DashboardHomeComponent},
  {path:"editDoctor/:id", component:UpdateDoctorComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
