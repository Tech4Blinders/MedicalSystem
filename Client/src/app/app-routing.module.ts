import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
{path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
{path:'register',loadChildren: ()=>import('./registeration/registeration.module').then(m=>m.RegisterationModule)},
{path:'visit',loadChildren: ()=>import('./hospital/hospital.module').then(m=>m.HospitalModule)}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
