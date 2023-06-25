import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/Services/appointment.service';
import { FullAppointment } from 'src/app/_Models/dtos/fullAppointment';

@Component({
  selector: 'app-patientmeeting',
  templateUrl: './patientmeeting.component.html',
  styleUrls: ['./patientmeeting.component.css']
})
export class PatientmeetingComponent implements OnInit {

  public appointments: FullAppointment[] = [];
  constructor(private appointmentService: AppointmentService) {}
  ngOnInit(): void {
    this.appointmentService.getAppointmentByPatientId(1).subscribe({
      next: (data) => {
        this.appointments = data;
      },
    });
  }
}

