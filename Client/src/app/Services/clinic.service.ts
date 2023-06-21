import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Clinic } from '../_Models/dtos/clinic';

@Injectable({
  providedIn: 'root',
})
export class ClinicService {
  constructor(private http: HttpClient) {}

  private clinic$ = new BehaviorSubject<any>({});
  private apiUrl = 'https://localhost:7025/api/Clinic';
  getClinic(clinicId: number): Observable<Clinic> {
    return this.http.get<Clinic>(`${this.apiUrl}/${clinicId}`);
  }
  getAllClinics():Observable<Clinic[]>
  {
    return this.http.get<Clinic[]>(this.apiUrl);
  }
  
  setClinic(clinic) {
    this.clinic$.next(clinic);
  }
  getCurrentClinic() {
    return this.clinic$;
  }
}
