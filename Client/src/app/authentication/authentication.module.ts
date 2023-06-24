import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterationComponent } from './registeration/registeration.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
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

  ],
  exports:[RegisterationComponent , LoginComponent] ,
})
export class AuthenticationModule {


 }
