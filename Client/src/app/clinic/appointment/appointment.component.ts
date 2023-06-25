import { Component, OnInit } from '@angular/core';
import {  ActivatedRoute, Router } from '@angular/router';
import { AppointmentService } from 'src/app/Services/appointment.service';
import { AvaliableAppointmentService } from 'src/app/Services/avaliable-appointment.service';
import { BranchService } from 'src/app/Services/branch.service';
import { DoctorService } from 'src/app/Services/doctor.service';
import { PatientService } from 'src/app/Services/patient.service';
import { Appointment } from 'src/app/_Models/dtos/appointment';
import { AvaliableAppointment } from 'src/app/_Models/dtos/avaliableappointment';
import { Branch } from 'src/app/_Models/dtos/branch';
import { Doctor } from 'src/app/_Models/dtos/doctor';
import { Patient } from 'src/app/_Models/dtos/patient';
import { Review } from 'src/app/_Models/dtos/review';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css'],
})
export class AppointmentComponent implements OnInit {
  public appointments: AvaliableAppointment[];
  public actualAppointment:Appointment=new Appointment();
  public selectedAppointment: Date[];
  public doctor: Doctor;
  public reviews:Review[];
  public checked:boolean=false;
  private patient:Patient;
  private branch:Branch;
  constructor(
    private avaliableAppointmentservice: AvaliableAppointmentService,
    private route:ActivatedRoute,
    private doctorService: DoctorService,
    private router:Router,
    private patientService:PatientService,
    private branchService:BranchService,
    private appointmentService:AppointmentService
  ) {}
  ngOnInit(): void {
    this.doctorService.getCurrentDoctor().subscribe(data=>{
      this.doctor=data;
      console.log(this.doctor);
    })
    this.doctorService.getDoctor(this.doctor.id ?? 1).subscribe((data) => {
      this.doctor = data;      
    });
    this.avaliableAppointmentservice
      .getAvaliableAppointments(this.doctor.id ?? 1)
      .subscribe((data) => {
        this.appointments = data;
      });
      this.doctorService.getDoctorReviews(this.doctor.id  ?? 1).subscribe(data=>{
        this.reviews=data;
        console.log(data);
      });
      // this.patientService.getCurrentPatient().subscribe(data=>{
      //   this.patient=data;
      // })
      this.patientService.getPatient(1).subscribe(data=>{
        this.patient=data;
      })
      this.patientService.setPatient(this.patient);
      this.branchService.getCurrentHospital().subscribe(data=>{
        this.branch=data;
      })
  }
  SelectAppointment(appointment: AvaliableAppointment) {
    
    this.actualAppointment.date=appointment.date;
    this.actualAppointment.doctorId=appointment.doctorId;
    if(this.checked)
    {
      this.actualAppointment.cost=this.doctor.onlineCost;
      this.actualAppointment.isOnline=true
    }
    else
    {
      this.actualAppointment.cost=this.doctor.offlineCost;
      this.actualAppointment.isOnline=false
    }
    this.actualAppointment.patientId=this.patient.id;
    this.actualAppointment.branchId=this.branch.id;
    
    this.appointmentService.setAppointment(this.actualAppointment);
    this.router.navigate(["payment"],{relativeTo:this.route})

  }
}
