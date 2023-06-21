import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ClinicServiceService {
  baseUrl = 'https://localhost:7025/api/';
  doctorsOfClinic: any[] = [];
  constructor(private http: HttpClient) {}

  getAllClinics() {
    return this.http.get(this.baseUrl + 'Clinic').pipe(
      catchError((err) => {
        console.log(err);
        throw 'something went wrong ' + err;
      })
    );
  }

  getDoctors(id: Number) {
    return this.http.get(this.baseUrl + 'Doctor/clinic/' + id);
  }
}
