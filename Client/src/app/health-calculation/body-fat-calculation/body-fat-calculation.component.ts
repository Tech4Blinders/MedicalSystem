import { Component } from '@angular/core';
import { healthCalcService } from 'src/app/Services/healthCalc.service';
import { bodyFatPercentage } from 'src/app/_Models/dtos/healthCalculatorDtos/BodyFatPercentage';
import { BodyFatResponse } from 'src/app/_Models/dtos/healthCalculatorDtos/BodyFatPercentageResponse';

@Component({
  selector: 'app-body-fat-calculation',
  templateUrl: './body-fat-calculation.component.html',
  styleUrls: ['./body-fat-calculation.component.css']
})
export class BodyFatCalculationComponent {
  
  bdyFatCalc: bodyFatPercentage = new bodyFatPercentage();
  bdyFatResponse: BodyFatResponse = new BodyFatResponse();

  
  constructor(public healthService: healthCalcService) { }
  add() {
      this.healthService.bodyFatePercentage(this.bdyFatCalc.gender ,this.bdyFatCalc.height ,this.bdyFatCalc.weight ,this.bdyFatCalc.age).subscribe((response) => {
        console.log(response);
        this.bdyFatResponse=response;
      });
    }
  }
