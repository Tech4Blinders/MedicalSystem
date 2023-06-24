import { Component } from '@angular/core';
import { AvaliableAppointmentService } from 'src/app/Services/avaliable-appointment.service';

@Component({
  selector: 'app-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.css']
})
export class MeetingComponent {

constructor(private appointmentService:AvaliableAppointmentService) {
}

}
