import { Component, OnInit } from '@angular/core';
import { ClinicService } from 'src/app/Services/clinic.service';
import { DoctorService } from 'src/app/Services/doctor.service';
import { PhotoService } from 'src/app/Services/photo.service';
import { Clinic } from 'src/app/_Models/dtos/clinic';
import { Doctor } from 'src/app/_Models/dtos/doctor';

@Component({
  selector: 'app-hosection2',
  templateUrl: './hosection2.component.html',
  styleUrls: ['./hosection2.component.css'],
})
export class HoSection2Component implements OnInit {
  doctorimages: any[];
  doctors:Doctor[];
  constructor(private doctorImg: PhotoService,private doctorService:DoctorService) {}
  ngOnInit(): void {
    this.doctorimages = this.doctorImg.getDoctorPhoto();
    this.doctorService.getAllDoctors().subscribe(data=>{
      this.doctors=data;
    })
    console.log(this.doctors);
    
  }
}
