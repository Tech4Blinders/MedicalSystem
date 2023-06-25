import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/Services/appointment.service';
import { FullAppointment } from 'src/app/_Models/dtos/fullAppointment';

@Component({
  selector: 'app-doctormeeting',
  templateUrl: './doctormeeting.component.html',
  styleUrls: ['./doctormeeting.component.css'],
})
export class DoctormeetingComponent implements OnInit {
  public appointments: FullAppointment[] = [];
  constructor(private appointmentService: AppointmentService) {}
  ngOnInit(): void {
    this.appointmentService.getAppointmentByDoctorId(1).subscribe({
      next: (data) => {
        this.appointments = data;
      },
    });
  }
}
