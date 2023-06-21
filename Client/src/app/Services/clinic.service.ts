import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Clinic } from '../_Models/dtos/clinic';
import { Doctor } from '../_Models/dtos/doctor';

@Injectable({
  providedIn: 'root',
})
export class ClinicService {
  constructor(private http: HttpClient) {}

  private clinic$ = new BehaviorSubject<any>({});
  private apiUrl = 'https://localhost:7025/api/';
  getClinic(clinicId: number): Observable<Clinic> {
    return this.http.get<Clinic>(`${this.apiUrl}/${clinicId}`);
  }
  getAllClinics():Observable<Clinic[]>
  {
    return this.http.get<Clinic[]>(this.apiUrl+"Clinic");
  }
  getClinicsByBranchId(id:number)
  {
    return this.http.get<Clinic[]>(this.apiUrl)
  }
  
  getClinicsByHosId(id:Number)
  {
    return this.http.get(this.apiUrl+"Clinic/HospitalClinics/"+id);
  }
  setClinic(clinic) {
    this.clinic$.next(clinic);
  }
  getCurrentClinic() {
    return this.clinic$;
  } 
  getDoctors(id: Number) {
    return this.http.get<Doctor[]>(this.apiUrl + 'Doctor/clinic/' + id);
  }
}
