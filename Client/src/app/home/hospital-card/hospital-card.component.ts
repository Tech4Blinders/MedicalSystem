import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService} from 'src/app/Services/branch.service';
import { Branch } from 'src/app/_Models/dtos/branch';
interface AutoCompleteCompleteEvent {
  originalEvent: Event;
  query: string;
}

@Component({
  selector: 'app-hospital-card',
  templateUrl: './hospital-card.component.html',
  styleUrls: ['./hospital-card.component.css']
})
export class HospitalCardComponent implements OnInit{

   hospitals: Branch[];
   route: ActivatedRoute
   constructor(private branchService: BranchService, private router:Router) {}

   ngOnInit(): void {
      this.getAllHos();
  }
 


    filteredHospitals: Branch[];
    selectedHospitalAdvanced: Branch[];
    getAllHos(){
       this.branchService.getAllHospitals().subscribe((data) => {
       this.hospitals=data;   
  })
}


    filterHospital(event:AutoCompleteCompleteEvent) {
      let filtered: Branch[] = [];
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
    this.branchService.setHospital(item)
    this.router.navigate(["visit"],{relativeTo:this.route})
  }



}
