import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from '../authenticator/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { DialogModule } from 'primeng/dialog';
import { ButtonModule } from 'primeng/button';
import { SelectButtonModule } from 'primeng/selectbutton';
import { SignoutGoogleComponent } from './signout-google/signout-google.component';
import { SigninGoogleComponent } from './signin-google/signin-google.component';


@NgModule({
  declarations: [
    RegisterationComponent,
    LoginComponent,
    SigninGoogleComponent,
    SignoutGoogleComponent
  ],
  imports: [
    CommonModule ,
    ReactiveFormsModule,
    HttpClientModule ,
    FormsModule ,
    RouterModule,
    DialogModule,
    ButtonModule,
    SelectButtonModule
    
  ]
    RouterModule,

  ],
  exports:[RegisterationComponent , LoginComponent] ,
})
export class AuthenticationModule {


 }
