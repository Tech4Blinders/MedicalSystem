import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './authentication/login/login.component';
import { RegisterationComponent } from './authentication/registeration/registeration.component';

const routes: Routes = [
{path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
{path:'register',component:RegisterationComponent },
{path:'login' , component:LoginComponent} , 
{path:'visit',loadChildren: ()=>import('./hospital/hospital.module').then(m=>m.HospitalModule)} , 
{path:'clinic',loadChildren: ()=>import('./clinic/clinic.module').then(m=>m.ClinicModule)} , 
{path:'dashboard',loadChildren: ()=>import('./dashboard/dashboard.module').then(m=>m.DashboardModule)} ,
{path:"meeting",loadChildren:()=>import('./meeting/meeting.module').then(m=>m.MeetingModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
