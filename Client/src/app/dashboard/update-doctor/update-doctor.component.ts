import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-update-doctor',
  templateUrl: './update-doctor.component.html',
  styleUrls: ['./update-doctor.component.css']
})
export class UpdateDoctorComponent {

  /**
   *
   */
  constructor(private activate: ActivatedRoute,private _router: Router,) {
  
    
  }

  doctForm = new FormGroup({
    Name:new FormControl("mayada",[Validators.required,Validators.minLength(3)]),
    PhoneNumber:new FormControl("mayada",[Validators.required]),
    Email:new FormControl("mayada",[Validators.required]),
    Gender:new FormControl("mayada",[Validators.required]),
    Country:new FormControl("mayada",[Validators.required]),
    City:new FormControl("mayada",[Validators.required]),
    Street:new FormControl("mayada",[Validators.required]),
    File:new FormControl("mayada",[Validators.required]),
    OfflineCost:new FormControl(5,[Validators.required]),
    OnlineCost:new FormControl(5,[Validators.required]),
  });

  onSubmit(){
this.activate.params.subscribe(a => {
  this._router.navigateByUrl("dashboard")
})
  }
}
