import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import{GalleriaModule} from 'primeng/galleria';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { CardModule } from 'primeng/card';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { Section1Component } from './section1/section1.component';
import { Section2Component } from './section2/section2.component';
import { Section4Component } from './section4/section4.component';
import { Section5Component } from './section5/section5.component';
import { Section7Component } from './section7/section7.component';
import { HospitalCardComponent } from './hospital-card/hospital-card.component'
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    HomeComponent,
    Section1Component,
    Section2Component,
    Section4Component,
    Section5Component,
    Section7Component,
    HospitalCardComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    GalleriaModule,
    AutoCompleteModule,
    FormsModule,
    CardModule
  ],
  exports:[
    HomeComponent,
    Section1Component,
    Section2Component,
    Section4Component,
    Section5Component,
    Section7Component
  ]
})
export class HomeModule { }
