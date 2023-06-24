import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable,tap } from 'rxjs';
import { Patient } from '../_Models/dtos/patient';
import { Review } from '../_Models/dtos/review';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  constructor(private http: HttpClient) {}

  private patient$ = new BehaviorSubject<any>({});
  private apiUrl = 'https://localhost:7025/api/Patient';
  private apiReview='https://localhost:7025/api/Review';
  getPatient(patientId:number):Observable<Patient>
  {
    return this.http.get<Patient>(`${this.apiUrl}/${patientId}`)
  }

  setPatient(patient) 
  {
    this.patient$.next(patient);
  }
  getCurrentPatient() 
  {
    return this.patient$;
  }
  getPatientReviews(id:number){
    return this.http.get<Review[]>(this.apiReview+`/${id}`).pipe(tap(e=>e.forEach(a=>a.rate=a.rate/20)))
  }
  getAllPatients(){
    return this.http.get<Patient[]>(this.apiUrl);
  }
}
