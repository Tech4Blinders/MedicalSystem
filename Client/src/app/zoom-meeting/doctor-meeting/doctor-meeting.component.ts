import { Observable } from 'rxjs';
import { AfterContentInit, Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import {tokenDto} from '../../_Models/dtos/tokenDto';
import { ZoomMeetingService } from 'src/app/Services/zoom-meeting.service';
import { MeetingData } from 'src/app/_Models/dtos/meetingData';
@Component({
  selector: 'app-doctor-meeting',
  templateUrl: './doctor-meeting.component.html',
  styleUrls: ['./doctor-meeting.component.css']
})
export class DoctorMeetingComponent implements OnInit  { //, AfterContentInit
  private code : string = '';
  private meetingData : MeetingData = new MeetingData();
  constructor (
    private route: ActivatedRoute,
    private http: HttpClient,
    private zoomMeetingService :ZoomMeetingService,
  ) {}
  ngOnInit(): void {
    this.code = this.route.snapshot.queryParamMap.get('code');
    // console.log('😝😝😝😝😝😝😝😝😝😝😝😝😝'+this.code+'😝😝😝😝😝😝😝😝😝😝😝😝😝😝')
    this.generateToken().subscribe(data => {
      this.meetingData.meetingId = data.id;
      this.meetingData.meetingPassword = data.password;
      this.meetingData.meetingStartTime = data.start_time;
      this.meetingData.duration = data.duration;

      this.zoomMeetingService.setMeeting(this.meetingData);
      // this.zoomMeetingService.meeting.next(this.meetingData);
      console.log(`Your Meeting is:😀😀😀😀😀😀😀😀😀${this.meetingData.meetingId},${this.meetingData.meetingPassword},${this.meetingData.meetingStartTime},${this.meetingData.duration}😀😀😀😀😀😀😀😀😀😀😀`);
    });
  }
  generateToken(): Observable<any> {
    const params = {code : this.code};
    return this.http.get<any>('https://localhost:7025/api/meeting', { params })
  }


}




