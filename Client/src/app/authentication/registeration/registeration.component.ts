import { Component } from '@angular/core';
import {FormGroup , FormControl ,Validators} from '@angular/forms' ;
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/Services/auth.service';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css']
})
export class RegisterationComponent {
  constructor(private _authService:AuthService ,private _router:Router) {
  }
  registerform:FormGroup = new FormGroup({
    Name:new FormControl(null,[Validators.required , Validators.minLength(3)]) , 
    Email:new FormControl(null , [Validators.required , Validators.email]) , 
    Password: new FormControl(null , Validators.required ) , 
    NumberOfBranches: new FormControl(null ,Validators.required) ,
    Picture : new FormControl(null , Validators.required)
  })
  handleRegisteration(registerform:FormGroup)
  {
     //console.log(registerform);
     if(registerform.valid)
     {
          console.log(registerform.value);
        this._router.navigate(['/login'])
        this._authService.register(registerform.value).subscribe({
         next:(response)=>{
            if(response.message=='success')
           {
             // go to login page 
             //this._router.navigate(['/login'])
           }
         } , 
         error:(err)=>console.log(err.error.errors.message)
         
         
        });
     }
     
  }  
}
