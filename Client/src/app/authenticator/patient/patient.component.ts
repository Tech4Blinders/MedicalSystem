import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { Display } from 'src/app/_Models/dtos/displaydto';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css'],
})
export class PatientComponent {
  constructor(
    private _authService: AuthService,
    private _router: Router,
    private formBuilder: FormBuilder,
    private route:ActivatedRoute
  ) {}
  value: string;

  Options: any[] = [
    {
      name: 'Patient',
      value: '',
    },

    {
      name: 'Doctor',
      value: 'doctor',
    },
    {
      name: 'Admin',
      value: 'admin',
    },
  ];
  fileData: File;
  visible: Boolean = false;
  messageClass = null;
  validRegisteration = false;
  sucessfulPayment = false;
  paymentMessage: string;

  registerform: FormGroup = new FormGroup({
    Name: new FormControl(null, [Validators.required, Validators.minLength(3)]),
    UserName: new FormControl(null, [
      Validators.required,
      Validators.minLength(3),
    ]),
    Email: new FormControl(null, [Validators.required, Validators.email]),
    Password: new FormControl(null, Validators.required),
    Gender: new FormControl(null, Validators.required),
    Picture: new FormControl(null, Validators.required),
    PhoneNumber: new FormControl(null, Validators.required),
    Age: new FormControl(null, Validators.required),
  });
  onFileSelected(event: any) {
    this.fileData = <File>event.target.files[0];
    console.log('File Uploaded');
  }
  handleRegisteration(registerform: FormGroup) {
    if (registerform.valid) {
      this.paymentMessage = 'Waiting....!';
      this.messageClass = 'alert alert-warning  text-center p-5 h3';
      this.sucessfulPayment = false;
      this.visible = true;
      this.validRegisteration = true;
      const formData = new FormData();
      formData.append('File', this.fileData);
      formData.append('name', this.registerform.value.Name);
      formData.append('userName', this.registerform.value.UserName);
      formData.append('email', this.registerform.value.Email);
      formData.append('password', this.registerform.value.Password);
      formData.append('gender', this.registerform.value.Gender);
      formData.append('phoneNumber', this.registerform.value.PhoneNumber);
      formData.append('age', this.registerform.value.Age);
      formData.append('role', "Patient");

      this._authService.register(formData).subscribe({
        next: (response) => {
          console.log(response);
          this.sucessfulPayment = true;
          this.messageClass = 'alert alert-success text-center p-5 h5';
          this.paymentMessage = `Sucessful Registeration \n
                  Welcome ${this.registerform.value.Name}
                 `;
        },
        error: (err) => {
          console.log(err)
          if (err) {
            this.messageClass = 'alert alert-danger  text-center p-5 h4';
            this.paymentMessage =
              'Failed Registeration Attempt, Please Try Again Later!';
          }
        },
      });
    }
  }
}
