import { Observable } from 'rxjs';
import { AfterContentInit, Component, OnInit } from '@angular/core';
import { ZoomMtg } from '@zoomus/websdk';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import {tokenDto} from '../../_Models/dtos/tokenDto';
ZoomMtg.setZoomJSLib('https://source.zoom.us/2.13.0/lib', '/av');
// Email : tech6blinders@gmail.com
// Password: techblinders2023
ZoomMtg.preLoadWasm();
ZoomMtg.prepareWebSDK();
// loads language files, also passes any error messages to the ui
ZoomMtg.i18n.load('en-US');
ZoomMtg.i18n.reload('en-US');

@Component({
  selector: 'app-doctor-meeting',
  templateUrl: './doctor-meeting.component.html',
  styleUrls: ['./doctor-meeting.component.css']
})
export class DoctorMeetingComponent implements OnInit  { //, AfterContentInit
  private code : string = '';
  private meetingId: any;
  private meetingPassword: any;
  private meetingStartTime: any;
  private duration: any;
  constructor (
    private route: ActivatedRoute,
    private http: HttpClient
  ) {}
  ngOnInit(): void {
    // this.code = this.route.snapshot.queryParamMap.get('code');
    // // console.log('😝😝😝😝😝😝😝😝😝😝😝😝😝'+this.code+'😝😝😝😝😝😝😝😝😝😝😝😝😝😝')
    // this.generateToken().subscribe(data => {
    //   this.meetingId = data.id;
    //   this.meetingPassword = data.password;
    //   this.meetingStartTime = data.start_time;
    //   this.duration = data.duration;

    //   this.showMeeting();
    //   console.log(`Your Meeting is:😀😀😀😀😀😀😀😀😀${this.meetingId},${this.meetingPassword},${this.meetingStartTime},${this.duration}😀😀😀😀😀😀😀😀😀😀😀`);
    // });
  }
  generateToken(): Observable<any> {
    const params = {code : this.code};
    return this.http.get<any>('https://localhost:7025/api/meeting', { params })
  }
  showMeeting() {
    // debugger
    let payload = {
      meetingNumber:this.meetingId,
      passWord:this.meetingPassword,
      sdkKey:'75Vsq2TiT8WBkw3Axb7pJA',
      sdkSecret:'j8aLbYB18LnBibjKCzJJ7MKvXjMQ4maR',
      userName:'mohamed',
      userEmail:'',
      role:'1',
      // zak:'eyJ0eXAiOiJKV1QiLCJzdiI6IjAwMDAwMSIsInptX3NrbSI6InptX28ybSIsImFsZyI6IkhTMjU2In0.eyJhdWQiOiJjbGllbnRzbSIsInVpZCI6Ik1nQVhUTnc2U19HUUR4WDgxU211elEiLCJpc3MiOiJ3ZWIiLCJzayI6IjAiLCJzdHkiOjEsIndjZCI6InVzMDUiLCJjbHQiOjAsImV4cCI6MTY4NzAyODU1NCwiaWF0IjoxNjg3MDIxMzU0LCJhaWQiOiI5TTRzelBvWVR3S0xNallFM0QwbGtnIiwiY2lkIjoiIn0.X6ve48JA6RcGdjUfv0fEFztYllIBVUoL0Z9WAoclX4E',
      leaveUrl:'https://localhost:4200/meeting/doctor'
    }

    ZoomMtg.generateSDKSignature({
      meetingNumber : payload.meetingNumber,
      role : payload.role,
      sdkKey : payload.sdkKey,
      sdkSecret : payload.sdkSecret,
      success: function (signature: any) {
        ZoomMtg.init( {
          leaveUrl:payload.meetingNumber,
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
  async ngAfterContentInit():Promise<any> {
    this.code = this.route.snapshot.queryParamMap.get('code');
    console.log('😝😝😝😝😝😝😝😝😝😝😝😝😝'+this.code+'😝😝😝😝😝😝😝😝😝😝😝😝😝😝')
    this.generateToken().subscribe(data => {
      this.meetingId = data.id;
      this.meetingPassword = data.password;
      this.meetingStartTime = data.start_time;
      this.duration = data.duration;
      this.showMeeting();
      console.log(`Your Meeting is:😀😀😀😀😀😀😀😀😀${this.meetingId},${this.meetingPassword},${this.meetingStartTime},${this.duration}😀😀😀😀😀😀😀😀😀😀😀`);
    });

    // let payload = {
    //   meetingNumber:this.meetingId,
    //   passWord:this.meetingPassword,
    //   sdkKey:'75Vsq2TiT8WBkw3Axb7pJA',
    //   sdkSecret:'j8aLbYB18LnBibjKCzJJ7MKvXjMQ4maR',
    //   userName:'mohamed',
    //   userEmail:'',
    //   role:'1',
    //   // zak:'eyJ0eXAiOiJKV1QiLCJzdiI6IjAwMDAwMSIsInptX3NrbSI6InptX28ybSIsImFsZyI6IkhTMjU2In0.eyJhdWQiOiJjbGllbnRzbSIsInVpZCI6Ik1nQVhUTnc2U19HUUR4WDgxU211elEiLCJpc3MiOiJ3ZWIiLCJzayI6IjAiLCJzdHkiOjEsIndjZCI6InVzMDUiLCJjbHQiOjAsImV4cCI6MTY4NzAyODU1NCwiaWF0IjoxNjg3MDIxMzU0LCJhaWQiOiI5TTRzelBvWVR3S0xNallFM0QwbGtnIiwiY2lkIjoiIn0.X6ve48JA6RcGdjUfv0fEFztYllIBVUoL0Z9WAoclX4E',
    //   leaveUrl:'https://localhost:4200/meeting/doctor'
    // }

    // ZoomMtg.generateSDKSignature({
    //   meetingNumber : payload.meetingNumber,
    //   role : payload.role,
    //   sdkKey : payload.sdkKey,
    //   sdkSecret : payload.sdkSecret,
    //   success: function (signature: any) {
    //     ZoomMtg.init( {
    //       leaveUrl:payload.meetingNumber,
    //       success: function(data:any) {
    //         ZoomMtg.join( {
    //           meetingNumber : payload.meetingNumber,
    //           passWord : payload.passWord,
    //           sdkKey : payload.sdkKey,
    //           userName : payload.userName,
    //           // userEmail : payload.userEmail,
    //           signature : signature.result,
    //           // tk:'',
    //           // zak:payload.zak,
    //           success:function(data:any) {
    //             console.log(data);
    //           },
    //           error:function(error:any) {
    //             console.log('--Error Join-->',error)
    //           }
    //         })
    //       }
    //     })

    //   },
    //   error: function (error:any) {
    //     console.log(error)
    //   }
    // })
  }
}




