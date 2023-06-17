import { Component, OnInit } from '@angular/core';
import { PhotoService } from 'src/app/auth/Services/Services/photo.service';

@Component({
  selector: 'app-hosection2',
  templateUrl: './hosection2.component.html',
  styleUrls: ['./hosection2.component.css'],
})
export class HoSection2Component implements OnInit {
  doctorimages: any[];
  constructor(private doctorImg: PhotoService) {}
  ngOnInit(): void {
    this.doctorimages = this.doctorImg.getDoctorPhoto();
    console.log(this.doctorimages);
  }
}
