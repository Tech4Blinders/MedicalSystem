import { Component, OnInit } from '@angular/core';
import { ClinicService } from 'src/app/Services/clinic.service';
import { PhotoService } from 'src/app/Services/photo.service';
import { Clinic } from 'src/app/_Models/dtos/clinic';

@Component({
  selector: 'app-slide-clinc',
  templateUrl: './slide-clinc.component.html',
  styleUrls: ['./slide-clinc.component.css']
})
export class SlideClincComponent implements OnInit {
  clinic:Clinic;
  image:any;
  constructor(public photoSer: PhotoService,private clinicService:ClinicService) {
  }
  ngOnInit(): void {
    this.clinicService.getCurrentClinic().subscribe(data=>{
      this.clinic=data;
      
    })
  }

  // images: any[] = this.photoSer.getPhotos()
  responsiveOptions: any[] = this.photoSer.getResponsiveOptions();
}
