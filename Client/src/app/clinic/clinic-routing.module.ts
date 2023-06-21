import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicHomeComponent } from './clinic-home/clinic-home.component';

const routes: Routes = [{path:"",component:ClinicHomeComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClinicRoutingModule { }
