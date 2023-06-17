import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HassanienRoutingModule } from './hassanien-routing.module';
import { C1Component } from './c1/c1.component';


@NgModule({
  declarations: [
    C1Component
  ],
  imports: [
    CommonModule,
    HassanienRoutingModule
  ]
})
export class HassanienModule { }
