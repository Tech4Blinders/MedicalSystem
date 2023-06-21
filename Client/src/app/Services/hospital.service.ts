import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HospitalService {

  baseUrl="https://localhost:7025/api/";
  
  constructor(private http: HttpClient) { }
  currentHospital = new BehaviorSubject<any>([]);

  getAllHospitals(){
    return this.http.get(this.baseUrl+"branch");
  }

  setHospital(hospital){
    this.currentHospital.next(hospital);
  }
  getCurrentHospital(){
    return this.currentHospital;
  }
}
