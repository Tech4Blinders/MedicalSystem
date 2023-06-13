import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { Route, RouterModule, Routes } from '@angular/router';
import { CoreRoutingModule } from './core-routing.module';


const routes:Routes =[]
@NgModule({
  declarations: [
    NavbarComponent,
    FooterComponent,
    
  ],
  imports: [
    CommonModule,RouterModule, CoreRoutingModule
  ],
  exports:[
    NavbarComponent,
    FooterComponent,
    
  ]
})
export class CoreModule { }
