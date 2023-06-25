import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute ,Router} from '@angular/router';
import { AppointmentService } from 'src/app/Services/appointment.service';
import { FullAppointment } from 'src/app/_Models/dtos/fullAppointment';

@Component({
  selector: 'app-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.css']
})
export class MeetingComponent {
  private code : string = '';
  public appointments: FullAppointment[] = [];
  constructor (
    private route: ActivatedRoute,
    private http: HttpClient,
    private router:Router,
    private appointmentService: AppointmentService
  ) {}
  ngOnInit(): void {
    this.appointmentService.getAppointmentByDoctorId(1).subscribe({
      next: (data) => {
        this.appointments = data;
      },
    });
  }
  createMeeting() {
    console.log('byeeeeeee')
    this.router.navigateByUrl('https://zoom.us/oauth/authorize?client_id=75Vsq2TiT8WBkw3Axb7pJA&response_type=code&redirect_uri=https://localhost:4200')
  }
  authorize() {
    const params = {
      client_id:'75Vsq2TiT8WBkw3Axb7pJA',
      response_type:'code',
      redirect_uri:'https://localhost:4200/meeting/test'
  }
    console.log('jjjijwidjwq')
    return this.http.get<any> (
      `https://zoom.us/oauth/authorize`,
      {
        params
      }
    )
  }
}

