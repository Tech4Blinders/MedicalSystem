import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClinicService } from 'src/app/Services/clinic.service';
import { PhotoService } from 'src/app/Services/photo.service';
import { Clinic } from 'src/app/_Models/dtos/clinic';

@Component({
  selector: 'app-card-section',
  templateUrl: './card-section.component.html',
  styleUrls: ['./card-section.component.css'],
})
export class CardSectionComponent implements OnInit {
  public clinics: Clinic[];
  constructor(
    public cardImg: PhotoService,
    public clinicService: ClinicService,
    public router:Router,
    public route:ActivatedRoute
  ) {}
  ngOnInit(): void {
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
