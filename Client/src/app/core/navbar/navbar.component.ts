import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { DoctorService } from 'src/app/Services/doctor.service';
import { PatientService } from 'src/app/Services/patient.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  public isLogged: boolean = false;
  role: string;
  name: string;
  constructor(
    private loggingService: AuthService,
    private patientService: PatientService,
    private doctorService: DoctorService
  ) {}
  ngOnInit(): void {
    this.loggingService.IsLogged().subscribe((data) => {
      this.isLogged = data;
      this.role = localStorage.getItem('Role');
      if (this.role == 'Patient') {
        this.patientService.getCurrentPatient().subscribe((data) => {
          this.name = 'Patient : ' + data.name;
          console.log(data);
        });
      }
      if (this.role == 'Doctor') {
        this.doctorService.getCurrentDoctor().subscribe((data) => {
          this.name = 'Doctor : ' + data.name;
          console.log(data);
        });
      }
    });
  }
  LogOut() {
    localStorage.removeItem('token');
    this.loggingService.Logging(false);
    localStorage.removeItem("Role");
  }
}
