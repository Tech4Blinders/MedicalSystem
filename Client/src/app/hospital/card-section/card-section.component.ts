import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService } from 'src/app/Services/branch.service';
import { ClinicService } from 'src/app/Services/clinic.service';
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
  public branch:Branch;
  constructor(
    public cardImg: PhotoService,
    public clinicService: ClinicService,
    public router:Router,
    public route:ActivatedRoute,
    public branchService:BranchService
  ) {}
  ngOnInit(): void {
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
