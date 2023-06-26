import { AfterViewChecked, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ZoomMeetingService } from 'src/app/Services/zoom-meeting.service';
import { MeetingJoinData } from 'src/app/_Models/dtos/MeetingJoinData';

@Component({
  selector: 'app-patient-meeting',
  templateUrl: './patient-meeting.component.html',
  styleUrls: ['./patient-meeting.component.css']
})
export class PatientMeetingComponent  implements OnInit{
  private meeting : MeetingJoinData;
  constructor(
    private zoomMeetingService: ZoomMeetingService,
    private router:Router,
    
  ){}
  ngOnInit() {
    this.zoomMeetingService
      .getPatientMeeting(1)
      .subscribe(meetingData  => {
        console.log(meetingData);
        this.meeting = meetingData});
  }
  ngOnDestroy(): void {
    // document.getElementById("hidefooter").style.display='block';
    // document.getElementById("hidenavbar").style.display='block';
  }
  async ngAfterContentInit():Promise<any> {
    // document.getElementById("zmmtg-root").style.display='block';
    // document.getElementById("hidefooter").style.display='none';
    // document.getElementById("hidenavbar").style.display='none';
  }

  joinMeeting()
  {
    console.log("Second"+this.meeting);
    this.zoomMeetingService.setJoinMeeting(this.meeting);
    this.router.navigate(['/meeting','joinmeeting']);
  }
}
