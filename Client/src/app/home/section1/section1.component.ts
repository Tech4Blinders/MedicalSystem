import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HospitalService } from 'src/app/Services/hospital.service';
import { PhotoService } from 'src/app/Services/photo.service';

@Component({
  selector: 'app-section1',
  templateUrl: './section1.component.html',
  styleUrls: ['./section1.component.css'],
})
export class Section1Component implements OnInit{
  id: string = '1';
  hospitals:any[];
  route:ActivatedRoute;
  constructor(private Photo: PhotoService, private hospitalService: HospitalService,private router:Router) {}

  ngOnInit(): void {
    this.getHospitals();
  }

  images: any[] = this.Photo.getPhotos();
  responsiveOptions: any[] = this.Photo.getResponsiveOptions();
  getHospitals(){
    this.hospitalService.getAllHospitals().subscribe((a:any) => {
      this.hospitals = a;
      console.log(a);
      
    })
  }
  setHospital(item:any){
    this.hospitalService.setHospital(item);
    this.router.navigate(["visit"],{relativeTo:this.route})
  }
}
