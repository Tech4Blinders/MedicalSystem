import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Branch } from '../_Models/dtos/branch';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  baseUrl="https://localhost:7025/api/";
  
  constructor(private http: HttpClient) { }
  currentHospital = new BehaviorSubject<any>([]);

  getAllHospitals(){
    return this.http.get<Branch[]>(this.baseUrl+"branch/address");
  }

  setHospital(hospital){
    this.currentHospital.next(hospital);
  }
  getCurrentHospital(){
    return this.currentHospital;
  }
}
