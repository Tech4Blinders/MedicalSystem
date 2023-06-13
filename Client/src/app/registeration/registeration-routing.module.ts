import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HospitalformComponent } from './hospitalform/hospitalform.component';

const routes: Routes = [
  {path:"",component:HospitalformComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegisterationRoutingModule { }
