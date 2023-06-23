import { BehaviorSubject, Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { MeetingData } from '../_Models/dtos/meetingData';
import { MeetingJoinData } from '../_Models/dtos/MeetingJoinData';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ZoomMeetingService {
  constructor(
    private http : HttpClient
  ) { }

  private meetingInitializer = new MeetingData();
  private meeting = new BehaviorSubject<MeetingData>(this.meetingInitializer);
  setMeeting(meetingData: MeetingData) {
    this.meeting.next(meetingData);
  }
  getMeeting() {
    return this.meeting.asObservable();
  }

  private meetingJoinInitializer = new MeetingJoinData();
  private meetingJoin = new BehaviorSubject<MeetingJoinData>(this.meetingJoinInitializer);
  setJoinMeeting(meetinJoinData: MeetingJoinData) {
    console.log(`😁😁😁${meetinJoinData}😁😁😁`);
    this.meetingJoin.next(meetinJoinData);
  }
  getJoinMeeting() {
    return this.meetingJoin.asObservable();
  }

  getPatientMeeting(appointmentId : number): Observable<MeetingJoinData> {
    // const params = {appointmentId:appointmentId};
    return this.http.get<MeetingJoinData>('https://localhost:7025/api/meeting/join', {params:{ appointmentId:appointmentId }})
  }

}


