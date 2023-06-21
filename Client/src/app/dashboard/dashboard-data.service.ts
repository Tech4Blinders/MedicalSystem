import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DashboardDataService {


  doctorsData :any[]=[]
  constructor() { }

  getDoctors(){
    return this.doctorsData = [
      {
        name:"ibrahim",
        imgSrc:"../../assets/images/doctor.png",
        qualifications:["master","doctor"],
        rating:5,
        country:"Alexandria"
      },
      {
        name:"ibrahim",
        imgSrc:"../../assets/images/doctor.png",
        qualifications:["master","doctor"],
        rating:5,
        country:"Alexandria"
      },
      {
        name:"ibrahim",
        imgSrc:"../../assets/images/doctor.png",
        qualifications:["master","doctor"],
        rating:5,
        country:"Alexandria"
      },
      {
        name:"ibrahim",
        imgSrc:"../../assets/images/doctor.png",
        qualifications:["master","doctor"],
        rating:5,
        country:"Alexandria"
      }

    ]
  }

}
