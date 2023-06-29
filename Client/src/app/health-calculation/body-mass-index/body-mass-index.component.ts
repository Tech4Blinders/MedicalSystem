import { Component } from '@angular/core';
import { healthCalcService } from 'src/app/Services/healthCalc.service';
import { bodyMassIndex } from 'src/app/_Models/dtos/healthCalculatorDtos/BodyMassIndex';
import { bodyMassIndexResponse } from 'src/app/_Models/dtos/healthCalculatorDtos/BodyMassIndexResponse';

@Component({
  selector: 'app-body-mass-index',
  templateUrl: './body-mass-index.component.html',
  styleUrls: ['./body-mass-index.component.css']
})
export class BodyMassIndexComponent {
bdyMassCalc: bodyMassIndex = new bodyMassIndex();
bdyMassResponse: bodyMassIndexResponse = new bodyMassIndexResponse();
checked:boolean=false;

  
  constructor(public healthService: healthCalcService) { }
  add() {
    
      this.healthService.bodyMassIndex(this.bdyMassCalc.height ,this.bdyMassCalc.weight ).subscribe((response) => {
        console.log(response);
        this.bdyMassResponse=response;
        this.checked=true;
      });
    }
}
