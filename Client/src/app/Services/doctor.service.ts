import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';
import { Doctor } from '../_Models/dtos/doctor';
import { Review } from '../_Models/dtos/review';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  constructor(private http: HttpClient) {}

  private doctor$ = new BehaviorSubject<any>({});
  private apiUrl = 'https://localhost:7025/api/Doctor';
  private apiReview='https://localhost:7025/api/Review';
  getDoctor(doctorId:number):Observable<Doctor>
  {
    return this.http.get<Doctor>(`${this.apiUrl}/${doctorId}`)
  }

  setDoctor(doctor) 
  {
    this.doctor$.next(doctor);
  }
  getCurrentDoctor()
  {
    return this.doctor$.asObservable();
  }
  getDoctorReviews(id:number){
    return this.http.get<Review[]>(this.apiReview+`/${id}`).pipe(tap(e=>e.forEach(a=>a.rate=a.rate/20)))
  }
  getAllDoctors(){
    return this.http.get<Doctor[]>(this.apiUrl);
  }
}
