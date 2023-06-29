import { Component } from '@angular/core';
import { healthCalcService } from 'src/app/Services/healthCalc.service';

@Component({
  selector: 'app-ideal-body-mass',
  templateUrl: './ideal-body-mass.component.html',
  styleUrls: ['./ideal-body-mass.component.css']
})
export class IdealBodyMassComponent {
  gender:string;
  height:number;
  body_frame:string;
  ideal_weight: any;
  checked:boolean=false;

constructor(public healthService: healthCalcService) { }
  add() {
      this.healthService.idealbodyMass(this.gender,this.height,this.body_frame).subscribe((response) => {
        console.log(response);
        this.ideal_weight=response;
        this.checked=true;
      });
    }
}
