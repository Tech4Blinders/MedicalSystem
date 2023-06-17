import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './authentication/login/login.component';
import { RegisterationComponent } from './authentication/registeration/registeration.component';

const routes: Routes = [
{path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
{path:'register',component:RegisterationComponent },
{path:'login' , component:LoginComponent} , 
{path:'visit',loadChildren: ()=>import('./hospital/hospital.module').then(m=>m.HospitalModule)} , 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
