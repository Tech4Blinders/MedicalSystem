import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { Route, RouterModule, Routes } from '@angular/router';
import { CoreRoutingModule } from './core-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import {  HttpClientModule } from '@angular/common/http';


const routes:Routes =[]
@NgModule({
  declarations: [
    NavbarComponent,
    FooterComponent,
    
  ],
  imports: [
    CommonModule,RouterModule, CoreRoutingModule , ReactiveFormsModule
  ],
  exports:[
    NavbarComponent,
    FooterComponent, 
    HttpClientModule ,
    RouterModule 
    
  ]
})
export class CoreModule { }
