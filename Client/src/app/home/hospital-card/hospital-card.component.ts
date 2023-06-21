import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HospitalService } from 'src/app/Services/hospital.service';

@Component({
  selector: 'app-hospital-card',
  templateUrl: './hospital-card.component.html',
  styleUrls: ['./hospital-card.component.css']
})
export class HospitalCardComponent implements OnInit{

   hospitals: any[];
   route: ActivatedRoute
   constructor(private hospitalSer: HospitalService, private router:Router) {}

   ngOnInit(): void {
      this.getAllHos();
  }
 


    filteredHospitals: any[];
    selectedHospitalAdvanced: any[];
    getAllHos(){
       this.hospitalSer.getAllHospitals().subscribe((a:any) => {
       this.hospitals=a;
       console.log(a);
    
  })
}


    filterHospital(event) {
      let filtered: any[] = [];
      let query = event.query;
      for (let i = 0; i < this.hospitals.length; i++) {
          let newHospital = this.hospitals[i];
          if (newHospital.name.toLowerCase().indexOf(query.toLowerCase()) == 0) {
              filtered.push(newHospital);
          }
      }
      this.filteredHospitals = filtered;
      console.log(this.filteredHospitals);
      
  }

  setHospital(item){
    console.log(item);
    this.hospitalSer.setHospital(item)
    this.router.navigate(["visit"],{relativeTo:this.route})
  }



}
