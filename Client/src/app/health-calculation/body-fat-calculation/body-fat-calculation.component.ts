import { Component } from '@angular/core';

@Component({
  selector: 'app-body-fat-calculation',
  templateUrl: './body-fat-calculation.component.html',
  styleUrls: ['./body-fat-calculation.component.css']
})
export class BodyFatCalculationComponent {
  constructor(public healthService: healthCalcService, private router: Router) {}
  add() {
    this.healthService.add(this.std).subscribe((a) => {
      console.log(a);
      this.router.navigateByUrl('/students');
    });
  }
}
