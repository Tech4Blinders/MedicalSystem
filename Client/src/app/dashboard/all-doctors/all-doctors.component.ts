import { Component } from '@angular/core';
import { DashboardDataService } from '../dashboard-data.service';

@Component({
  selector: 'app-all-doctors',
  templateUrl: './all-doctors.component.html',
  styleUrls: ['./all-doctors.component.css']
})
export class AllDoctorsComponent {

  constructor(private doctorInfo:DashboardDataService) {}
  doctorData: any[]= this.doctorInfo.getDoctors();
}
