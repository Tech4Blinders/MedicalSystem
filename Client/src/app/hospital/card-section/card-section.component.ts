import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService } from 'src/app/Services/branch.service';
import { ClinicService } from 'src/app/Services/clinic.service';
import { HospitalService } from 'src/app/Services/hospital.service';
import { PhotoService } from 'src/app/Services/photo.service';
import { Branch } from 'src/app/_Models/dtos/branch';
import { Clinic } from 'src/app/_Models/dtos/clinic';

@Component({
  selector: 'app-card-section',
  templateUrl: './card-section.component.html',
  styleUrls: ['./card-section.component.css'],
})
export class CardSectionComponent implements OnInit {
  public clinics: Clinic[];
  public clinicInHospital:Clinic[];
  public CurrentHospital;
  public branch:Branch;
  constructor(
    public cardImg: PhotoService,
    public clinicService: ClinicService,
    public hospitalService:HospitalService,
    public router:Router,
    public route:ActivatedRoute,
    public branchService:BranchService
  ) {}
  ngOnInit(): void {
    this.hospitalService.getCurrentHospital().subscribe((hospital:any) => {
      this.CurrentHospital=hospital;
      console.log("entered current hospital");
      console.log(this.CurrentHospital.id);
      
      
    })
    this.clinicService.getClinicsByHosId(this.CurrentHospital.id).subscribe((data:any) => {
      this.clinics = data;  
      console.log(data);        
    this.branchService.getCurrentHospital().subscribe(data=>{
      this.branch=data;
    });
    this.clinicService.getAllClinics().subscribe((data) => {
      this.clinics = data;      
    });
  }
  SelectClinic(item){
    this.clinicService.setClinic(item);
    this.router.navigate(["appointment"],{relativeTo:this.route})
    this.clinicService.getCurrentClinic().subscribe(a=>{
     
    })
  }
  images: any[] = this.cardImg.getClinicImgs();
}
