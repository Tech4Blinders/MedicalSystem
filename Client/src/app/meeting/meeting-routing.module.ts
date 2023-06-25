import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PatientmeetingComponent } from './patientmeeting/patientmeeting.component';
import { DoctormeetingComponent } from './doctormeeting/doctormeeting.component';

const routes: Routes = [{path:'',component:PatientmeetingComponent},
{path:"mymeeting",component:DoctormeetingComponent}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MeetingRoutingModule { }
