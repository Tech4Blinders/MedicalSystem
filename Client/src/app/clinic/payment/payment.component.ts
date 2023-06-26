import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AppointmentService } from 'src/app/Services/appointment.service';
import { PatientService } from 'src/app/Services/patient.service';
import { PaymentService } from 'src/app/Services/payment.service';
import { Appointment } from 'src/app/_Models/dtos/appointment';
import { Customer } from 'src/app/_Models/dtos/customerAdd';
import { CustomerPayment } from 'src/app/_Models/dtos/customerPayment';
import { Patient } from 'src/app/_Models/dtos/patient';
import { CustomerResponse } from 'src/app/_Models/dtos/stripeResponse';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css'],
})
export class PaymentComponent implements OnInit {
  private customerResponse: CustomerResponse = new CustomerResponse();
  public appointment: Appointment = new Appointment();
  public patient: Patient = new Patient();
  visible: Boolean = false;
  messageClass = null;
  validPayment = false;
  sucessfulPayment=false;
  paymentMessage: string;
  public customer:Customer=new Customer();
  constructor(
    private _payment: PaymentService,
    private route: ActivatedRoute,
    private patientService: PatientService,
    private router:Router,
    private appointmentService:AppointmentService
  ) {}
  ngOnInit(): void {
    this.patientService.getCurrentPatient().subscribe((data) => {
      this.patient = data;
      console.log(this.patient);
      this.paymentform.controls.email.setValue(this.patient.email);
      this.paymentform.controls.name.setValue(this.patient.name);
    });
    this.appointmentService.getCurrentAppointment().subscribe((appointment) => {
      this.appointment = appointment;
      console.log(this.appointment);
      
    });
  }
  public paymentform = new FormGroup({
    email: new FormControl(null, [Validators.email, Validators.required]),
    name: new FormControl(null, [Validators.minLength(3), Validators.required]),
    creditCard: new FormGroup({
      name: new FormControl(null),
      cardNumber: new FormControl(null),
      expirationYear: new FormControl(null),
      expirationMonth: new FormControl(null),
      cvc: new FormControl(null),
    }),
  });

  handlepayment(paymentform: FormGroup) {
    if (paymentform.valid){
      this._payment.checkout(paymentform.value).subscribe({
        next: (response) => {
          this.customerResponse = response;
          const payment = new CustomerPayment(
            this.customerResponse.customerId,
            this.customerResponse.email,
            `Payment From${this.patient.email} to DoctorId : ${this.appointment.doctorId}`,
            'USD',
            this.appointment.cost
          );
          this._payment.pay(payment).subscribe({
            next: (data) => {
              console.log(this.appointment);
              
              this.appointmentService.MakeReservation(this.appointment).subscribe({
                next:(data)=>{
                  this.sucessfulPayment=true;
                  this.messageClass = 'alert alert-success text-center p-5 h5';
                  this.paymentMessage = `Sucessful Payment for
                 ${this.appointment.cost}$ \n We will be waiting for you 
                 ${this.patient.name} `;
                 
                },
                error:(data)=>{
                  if (data) {
                    this.messageClass = 'alert alert-danger  text-center p-5 h4';
                    this.paymentMessage = 'Failed Payment Attempt, Server Failure !';
                  }
                }
              })
              
            },
            error: (data) => {
              if (data) {
                this.messageClass = 'alert alert-danger  text-center p-5 h4';
                this.paymentMessage = 'Failed Payment Attempt, Please Try Again !';
              }
            },
          });
        },
        error: (data) => {
          console.log(data);
          if (data) {
            this.messageClass = 'alert alert-danger  text-center p-5 h4';
            this.paymentMessage = 'Failed Payment Attempt, Please Try Again !';
          }
        },
      });
    }
  }

  ShowDialog() {
    this.paymentMessage = 'Waiting....!';
    this.messageClass = 'alert alert-warning  text-center p-5 h3';
    this.sucessfulPayment=false;
    this.visible = true;
    this.validPayment = true;
  }
  navigateToMeeting(){
    this.router.navigate(["/meeting"]);
  }
}
