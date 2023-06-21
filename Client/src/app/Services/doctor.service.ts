import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Doctor } from '../_Models/dtos/doctor';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  constructor(private http: HttpClient) {}

  private doctor$ = new BehaviorSubject<any>({});
  private apiUrl = 'https://localhost:7025/api/Doctor';
  getDoctor(doctorId:number):Observable<Doctor>
  {
    return this.http.get<Doctor>(`${this.apiUrl}/${doctorId}`)
  }

  setDoctor(doctor) {
    this.doctor$.next(doctor);
  }
  getCurrentDoctor() {
    return this.doctor$;
  }
}
