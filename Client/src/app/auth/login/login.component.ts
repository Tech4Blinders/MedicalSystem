import { Component } from '@angular/core';
import { FormControl , FormGroup , Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private _authservice:AuthService , private _router:Router) {
    
  }
   loginform:FormGroup=new FormGroup({
    Email:new FormControl(null , [Validators.required , Validators.email]) , 
    Password: new FormControl(null , Validators.required) 
   })
    handleLogin(loginform:FormGroup)
    {
       if(loginform.valid)
       {
        this._router.navigate(['/home']) ;
         this._authservice.login(loginform.value).subscribe({
          next:(response)=>{
            if(response.message=="login succesffuly")
            {
                 this._router.navigate(['/home']) ;
            }
          } , 
          error:(err)=>console.log(err.error.errors.message)
          
         })
       }
    }
}
