import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClinicService {

  baseUrl="https://localhost:7025/api/";
  currentClinic= new BehaviorSubject<any>([]);
  
  constructor(private http: HttpClient) { }
}
