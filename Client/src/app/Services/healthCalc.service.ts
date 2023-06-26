import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, tap } from 'rxjs';
import { Doctor } from '../_Models/dtos/doctor';
import { Review } from '../_Models/dtos/review';

@Injectable({
  providedIn: 'root',
})
export class healthCalcService {
  constructor(private http: HttpClient) {}

  // private doctor$ = new BehaviorSubject<any>({});
  private apiUrl = 'https://health-calculator-api.p.rapidapi.com/';
  bodyFatePercentage(gender , height ,weight ,age){
    return this.http.get<any>(this.apiUrl+`bodyfat/imperial?gender=${gender}&height=${height}&weight=${weight}&age=${age}`);
  }
  bodyMassIndex(height,weight){
    return this.http.get<any>(this.apiUrl + `bmi/imperial?height=${height}&weight=${weight}`);
  }
  idealbodyMass(gender,height,body_frame){
    return this.http.get<any>(this.apiUrl+`ibw?gender=${gender}&height=${height}&body_frame=${body_frame}`);
  }
  DailyCaloricNeed(gender,height,weight,age,activity_level,goal){
    return this.http.get<any>(this.apiUrl+`dcn?gender=${gender}&height=${height}&weight=${weight}&age=${age}&activity_level=${activity_level}&goal=${goal}`);
  }
  dailyWaterIntake(activity_level,climate,weight){
    return this.http.get<any>(this.apiUrl+`dwi?activity_level=${activity_level}&climate=${climate}&weight=${weight}&unit=liters`);
  }
  targetHeartRate(fitness_level,age){
    return this.http.get<any>(this.apiUrl+`thr?fitness_level=${fitness_level}&age=${age}`);
  }
  macroNutrientDistribution(activity_level,body_composition_goal,dietary_preferences){
    return this.http.get<any>(this.apiUrl+`mnd?activity_level=${activity_level}&body_composition_goal=${body_composition_goal}&dietary_preferences=${dietary_preferences}`);
  }



  // getDoctorReviews(id:number){
  //   return this.http.get<Review[]>(this.apiReview+`/${id}`).pipe(tap(e=>e.forEach(a=>a.rate=a.rate/20)))
  // }
  // getDoctor(doctorId:number):Observable<Doctor>
  // {
  //   return this.http.get<Doctor>(`${this.apiUrl}/${doctorId}`)
  // }

  // setDoctor(doctor) 
  // {
  //   this.doctor$.next(doctor);
  // }
  // getCurrentDoctor()
  // {
  //   return this.doctor$.asObservable();
  // }
}

