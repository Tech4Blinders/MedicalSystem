import { Component, OnInit } from '@angular/core';
import { ClinicServiceService } from '../clinic-service.service';

@Component({
  selector: 'app-doctor-card',
  templateUrl: './doctor-card.component.html',
  styleUrls: ['./doctor-card.component.css']
})
export class DoctorCardComponent implements OnInit{

value:Number= 3;
doctorsInfo: any[];
constructor(private doctors: ClinicServiceService) {}

  ngOnInit(): void {
    this.getDoctorsInfo(1);
  }

  getDoctorsInfo(id:Number){
    this.doctors.getDoctors(id).subscribe((a:any) => {
      console.log(a);
      this.doctorsInfo=a;
    })
  }

}
