import { Component, OnInit } from '@angular/core';
import { HospitalService } from 'src/app/Services/hospital.service';
import { PhotoService } from 'src/app/Services/photo.service';
import { ClinicServiceService } from 'src/app/clinic/clinic-service.service';

@Component({
  selector: 'app-card-section',
  templateUrl: './card-section.component.html',
  styleUrls: ['./card-section.component.css']
})
export class CardSectionComponent implements OnInit {

constructor(public hospital: HospitalService, public clinics:ClinicServiceService) {}
  ngOnInit(): void {
    this.getAll();
  }

// images: any[] = this.cardImg.getClinicImgs();
clinicsInfo: any[]=[];
getAll(){
  this.clinics.getAllClinics().subscribe((a:any) => {
    this.clinicsInfo= a;
    console.log(this.clinicsInfo);
    console.log("current hospital");
    console.log(this.hospital.getCurrentHospital());
    
  })
}



}
