import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Appointment } from '../_Models/dtos/appointment';
import { FullAppointment } from '../_Models/dtos/fullAppointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {

  constructor(private http:HttpClient) { }
  private apiUrl = 'https://localhost:7025/api/Appointment';
  private apiUrlForAppointment = 'https://localhost:7025/api/AvaliableAppointment';

  private appointment$ = new BehaviorSubject<any>({});

  MakeReservation(appointment:Appointment)
  {
    console.log(appointment);
    
    return this.http.post<Appointment>(this.apiUrlForAppointment+"/MakeReservation",appointment)
  }
  setAppointment(appointment:Appointment)
  {
    this.appointment$.next(appointment);
  }
  getCurrentAppointment()
  {
    return this.appointment$.asObservable();
  }
  getAppointmentByDoctorId(id:number)
  {
    return this.http.get<FullAppointment[]>(this.apiUrl+"/DoctorId",{params:{id:id}});
  }
  getAppointmentByPatientId(id:number)
  {
    return this.http.get<FullAppointment[]>(this.apiUrl+"/PatientId",{params:{id:id}});
  }

}
