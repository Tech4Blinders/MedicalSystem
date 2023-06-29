
import {  Component } from '@angular/core';
import { ZoomMtg } from '@zoomus/websdk';
import { DoctorService } from 'src/app/Services/doctor.service';
import { ZoomMeetingService } from 'src/app/Services/zoom-meeting.service';
import { Doctor } from 'src/app/_Models/dtos/doctor';
import { MeetingData } from 'src/app/_Models/dtos/meetingData';

ZoomMtg.setZoomJSLib('https://source.zoom.us/2.13.0/lib', '/av');
// Email : tech6blinders@gmail.com
// Password: techblinders2023
ZoomMtg.preLoadWasm();
ZoomMtg.prepareWebSDK();
// loads language files, also passes any error messages to the ui
ZoomMtg.i18n.load('en-US');
ZoomMtg.i18n.reload('en-US');

@Component({
  selector: 'app-start-meeting',
  templateUrl: './start-meeting.component.html',
  styleUrls: ['./start-meeting.component.css']
})
export class StartMeetingComponent {
  private meeting : MeetingData;
  public doctor:Doctor;
  constructor(
    private zoomMeetingService : ZoomMeetingService,
    private doctorService:DoctorService
  ){}
  async ngAfterContentInit():Promise<any> {
    this.doctorService.getCurrentDoctor().subscribe(data=>{
      this.doctor=data;
    })
    document.getElementById("zmmtg-root").style.display='block';
    document.getElementById("hidefooter").style.display='none';
    document.getElementById("hidenavbar").style.display='none';

    


    this.zoomMeetingService.getMeeting().subscribe((meetingData:MeetingData) => {
      this.meeting = meetingData;
    })
    let payload = {
      meetingNumber:this.meeting.meetingId,
      passWord:this.meeting.meetingPassword,
      sdkKey:'Secret-Key',
      sdkSecret:'SDK-Secret-Key',
      userName:this.doctor?.name ?? "Doctor",
      userEmail:this.doctor?.email ?? "Doctor@medico.com",
      role:'1',
      // zak:'eyJ0eXAiOiJKV1QiLCJzdiI6IjAwMDAwMSIsInptX3NrbSI6InptX28ybSIsImFsZyI6IkhTMjU2In0.eyJhdWQiOiJjbGllbnRzbSIsInVpZCI6Ik1nQVhUTnc2U19HUUR4WDgxU211elEiLCJpc3MiOiJ3ZWIiLCJzayI6IjAiLCJzdHkiOjEsIndjZCI6InVzMDUiLCJjbHQiOjAsImV4cCI6MTY4NzAyODU1NCwiaWF0IjoxNjg3MDIxMzU0LCJhaWQiOiI5TTRzelBvWVR3S0xNallFM0QwbGtnIiwiY2lkIjoiIn0.X6ve48JA6RcGdjUfv0fEFztYllIBVUoL0Z9WAoclX4E',
      leaveUrl:'https://localhost:4200/meeting/startmeeting'
    }

    ZoomMtg.generateSDKSignature({
      meetingNumber : payload.meetingNumber.toString(),
      role : payload.role,
      sdkKey : payload.sdkKey,
      sdkSecret : payload.sdkSecret,
      success: function (signature: any) {
        ZoomMtg.init( {
          leaveUrl:payload.leaveUrl,
          success: function(data:any) {
            ZoomMtg.join( {
              meetingNumber : payload.meetingNumber,
              passWord : payload.passWord,
              sdkKey : payload.sdkKey,
              userName : payload.userName,
              // userEmail : payload.userEmail,
              signature : signature.result,
              // tk:'',
              // zak:payload.zak,
              success:function(data:any) {
                console.log(data);
              },
              error:function(error:any) {
                console.log('--Error Join-->',error)
              }
            })
          }
        })

      },
      error: function (error:any) {
        console.log(error)
      }
    })
  }
}
