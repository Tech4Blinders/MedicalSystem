import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AvaliableAppointment } from '../_Models/dtos/avaliableappointment';

@Injectable({
  providedIn: 'root',
})
export class AvaliableAppointmentService {
  private avaliableAppointment$ = new BehaviorSubject<any>({});
  private apiUrl = 'https://localhost:7025/api/AvaliableAppointment/DoctorAvailableAppointments';
  constructor(private http: HttpClient) {}
  getAvaliableAppointments(doctorId:number):Observable<AvaliableAppointment[]>
  {
    return this.http.get<any>(`${this.apiUrl}/${doctorId}`);
  }
  setAppointment(appointment:AvaliableAppointment)
  {
    this.avaliableAppointment$.next(appointment);
  }
  getCurrentAppointment()
  {
    return this.avaliableAppointment$.asObservable();
  }
}
