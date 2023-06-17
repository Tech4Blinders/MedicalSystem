import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { Router, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './register/register.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  exports:[RegisterComponent , LoginComponent] , 
  imports: [
    CommonModule , 
    ReactiveFormsModule , 
    RouterModule , 
    HttpClientModule , 
    RouterModule ,
    NgModule
    
  ]
})
export class AuthModule { }
