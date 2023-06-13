import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HospitalComponent } from './hospital.component';
import { HoSection2Component } from './hosection2/hosection2.component';
import { HospitalRoutingModule } from './hospital-routing.module';
import { Hosection1Component } from './hosection1/hosection1.component';

@NgModule({
  declarations: [HospitalComponent, HoSection2Component, Hosection1Component],
  imports: [CommonModule, HospitalRoutingModule],
  exports: [HoSection2Component, Hosection1Component],
})
export class HospitalModule {}
