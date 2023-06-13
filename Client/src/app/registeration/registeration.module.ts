import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegisterationRoutingModule } from './registeration-routing.module';
import { HospitalformComponent } from './hospitalform/hospitalform.component';


@NgModule({
  declarations: [
    HospitalformComponent
  ],
  imports: [
    CommonModule,
    RegisterationRoutingModule
  ]
})
export class RegisterationModule { }
