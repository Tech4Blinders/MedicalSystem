import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { BranchService } from 'src/app/Services/branch.service';
import { DoctorService } from 'src/app/Services/doctor.service';
import { PatientService } from 'src/app/Services/patient.service';
import { Doctor } from 'src/app/_Models/dtos/doctor';
import { LoginDto } from 'src/app/_Models/dtos/login.dto';
import { Patient } from 'src/app/_Models/dtos/patient';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  constructor(
    private _authservice: AuthService,
    private _router: Router,
    private patientService: PatientService,
    private doctorService:DoctorService,
  ) {}
  public patient: Patient;
  loginform: FormGroup = new FormGroup({
    UserName: new FormControl(null, [Validators.required]),
    Password: new FormControl(null, Validators.required),
  });
  handleLogin(loginform: FormGroup) {
    if (loginform.valid) {
      this._authservice.login(loginform.value as LoginDto).subscribe({
        next: (response) => {
          console.log(response.token);
          localStorage.setItem('token', response.token);
          this._authservice.Logging(true);
          if (response.role == 'Patient') {
            this.patientService.getPatient(response.id).subscribe((data) => {
              this.patient = data;
              this.patientService.setPatient(this.patient);
              localStorage.setItem("Role","Patient");
            });
          }

          if (response.role == 'Doctor') {
            this.doctorService.getDoctor(response.id).subscribe((data) => {
              let doctor=new Doctor();
              doctor = data;
              this.doctorService.setDoctor(doctor);
              localStorage.setItem("Role","Doctor");
          this._authservice.Logging(true);


            });
          }
         
          // if (response.role == 'Admin') {
          //   this.branchService.(response.id).subscribe((data) => {
          //     this.patient = data;
          //     this.patientService.setPatient(this.patient);
          //   });
          // }

          this._router.navigate(['/'], { replaceUrl: true });
        },
        error: (err) =>{
          //  console.log(err.error.errors.message)
           alert("Wrong Credentials");
          },
      });
    }
  }
}
