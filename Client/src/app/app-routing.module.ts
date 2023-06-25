import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
{path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
{path:'register', loadChildren: () => import('./authenticator/authenticator.module').then(m => m.AuthenticatorModule  ) },
{path:'visit',loadChildren: ()=>import('./hospital/hospital.module').then(m=>m.HospitalModule)} ,
{path:'clinic',loadChildren: ()=>import('./clinic/clinic.module').then(m=>m.ClinicModule)} ,
{path:'dashboard',loadChildren: ()=>import('./dashboard/dashboard.module').then(m=>m.DashboardModule)} ,
{path:"reservations",loadChildren:()=>import('./meeting/meeting.module').then(m=>m.MeetingModule)},
{path:'meeting',loadChildren: ()=>import('./zoom-meeting/zoom-meeting.module').then(m=>m.ZoomMeetingModule)} ,

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
