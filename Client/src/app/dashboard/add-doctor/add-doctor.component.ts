import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-doctor',
  templateUrl: './add-doctor.component.html',
  styleUrls: ['./add-doctor.component.css']
})
export class AddDoctorComponent {


  addFlag:Boolean= false;
  
  @Output() 
  hideForm = new EventEmitter<Boolean>();

  doctForm = new FormGroup({
    Name:new FormControl(null,[Validators.required,Validators.minLength(3)]),
    PhoneNumber:new FormControl(null,[Validators.required]),
    Email:new FormControl(null,[Validators.required]),
    Gender:new FormControl(null,[Validators.required]),
    Country:new FormControl(null,[Validators.required]),
    City:new FormControl(null,[Validators.required]),
    Street:new FormControl(null,[Validators.required]),
    File:new FormControl(null,[Validators.required]),
    OfflineCost:new FormControl(null,[Validators.required]),
    OnlineCost:new FormControl(null,[Validators.required]),
  });

    //add doctor and call service to save doctor
    onSubmit(){
      console.log(this.doctForm.value);
      // call service
      //redirect to allDoctor
      this.addFlag=false;
      this.hideForm.emit(this.addFlag)
    }
}
