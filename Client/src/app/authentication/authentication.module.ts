import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterationComponent } from './registeration/registeration.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    RegisterationComponent,
    LoginComponent
  ],
  exports:[RegisterationComponent , LoginComponent] ,
  imports: [
    CommonModule , 
    ReactiveFormsModule,
    HttpClientModule ,
    FormsModule ,
    RouterModule
  ]
})
export class AuthenticationModule { }
