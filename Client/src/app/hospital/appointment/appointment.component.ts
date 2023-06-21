import { Component, OnInit } from '@angular/core';
import { AvaliableAppointmentService } from 'src/app/Services/avaliable-appointment.service';
import { ClinicService } from 'src/app/Services/clinic.service';
import { DoctorService } from 'src/app/Services/doctor.service';
import { AvaliableAppointment } from 'src/app/_Models/dtos/avaliableappointment';
import { Doctor } from 'src/app/_Models/dtos/doctor';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css'],
})
export class AppointmentComponent implements OnInit {
  public appointments: AvaliableAppointment[];
  public selectedAppointment: Date[];
  public doctor: Doctor;
  constructor(
    private appointmentservice: AvaliableAppointmentService,
    private doctorService: DoctorService,
  ) {}
  ngOnInit(): void {
    this.doctorService.getDoctor(1).subscribe((data) => {
      this.doctor = data;      
    });
    this.appointmentservice
      .getAvaliableAppointments(1)
      .subscribe((data) => {
        this.appointments = data;
      });
  }
  SelectAppointment(element: AvaliableAppointment) {
    console.log(this.doctor);
  }
}
