import { Component, OnInit } from '@angular/core';
import { ClinicServiceService } from '../clinic-service.service';
import { ClinicService } from 'src/app/Services/clinic.service';
import { Doctor } from 'src/app/_Models/dtos/doctor';
import { DoctorService } from 'src/app/Services/doctor.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Review } from 'src/app/_Models/dtos/review';

@Component({
  selector: 'app-doctor-card',
  templateUrl: './doctor-card.component.html',
  styleUrls: ['./doctor-card.component.css']
})
export class DoctorCardComponent implements OnInit{

value:Number= 3;
doctorId:number=1;
doctorsInfo: any[];
constructor(private doctors: ClinicServiceService,
  private clinicService:ClinicService,
  private doctorService:DoctorService,
  private router:Router,
  private route:ActivatedRoute) {}

  ngOnInit(): void {
    this.clinicService.getCurrentClinic().subscribe(data=>{
      this.doctorId=data.id;
    });
    this.getDoctorsInfo(this.doctorId);
  }

  getDoctorsInfo(id:number){
    this.doctors.getDoctors(id).subscribe((a:any) => {
      this.doctorsInfo=a;
      console.log(this.doctorsInfo)
    })

  }
  SelectDoctor(doctor:Doctor){
    this.doctorService.setDoctor(doctor);
    
    this.router.navigate(["appointment"],{relativeTo:this.route})
  }

}
