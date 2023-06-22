import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, Router } from '@angular/router';
import { AvaliableAppointmentService } from 'src/app/Services/avaliable-appointment.service';
import { DoctorService } from 'src/app/Services/doctor.service';
import { AvaliableAppointment } from 'src/app/_Models/dtos/avaliableappointment';
import { Doctor } from 'src/app/_Models/dtos/doctor';
import { Review } from 'src/app/_Models/dtos/review';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css'],
})
export class AppointmentComponent implements OnInit {
  public appointments: AvaliableAppointment[];
  public selectedAppointment: Date[];
  public doctor: Doctor;
  public reviews:Review[];
  constructor(
    private appointmentservice: AvaliableAppointmentService,
    private doctorService: DoctorService,
    private router:Router,
    private route:ActivatedRoute
  ) {}
  ngOnInit(): void {
    this.doctorService.getCurrentDoctor().subscribe(data=>{
      this.doctor=data;
      console.log(this.doctor);
    })
    this.doctorService.getDoctor(this.doctor.id ?? 1).subscribe((data) => {
      this.doctor = data;      
    });
    this.appointmentservice
      .getAvaliableAppointments(this.doctor.id ?? 1)
      .subscribe((data) => {
        this.appointments = data;
      });
      this.doctorService.getDoctorReviews(this.doctor.id  ?? 1).subscribe(data=>{
        this.reviews=data;
        console.log(data);
        
      });
  }
  SelectAppointment(appointment: AvaliableAppointment) {
    console.log(appointment)
    this.appointmentservice.setAppointment(appointment);
    this.router.navigate(["clinic/meeting"],{replaceUrl:true})

  }
}
