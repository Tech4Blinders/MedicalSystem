import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HealthCalculationRoutingModule } from './health-calculation-routing.module';
import { BodyFatCalculationComponent } from './body-fat-calculation/body-fat-calculation.component';
import { BodyMassIndexComponent } from './body-mass-index/body-mass-index.component';
import { DailyCaloricNeedComponent } from './daily-caloric-need/daily-caloric-need.component';
import { IdealBodyMassComponent } from './ideal-body-mass/ideal-body-mass.component';
import { MacronutrientDistributionComponent } from './macronutrient-distribution/macronutrient-distribution.component';
import { TargetHeartRateComponent } from './target-heart-rate/target-heart-rate.component';
import { MaincomponentComponent } from './maincomponent/maincomponent.component';


@NgModule({
  declarations: [
    BodyFatCalculationComponent,
    BodyMassIndexComponent,
    DailyCaloricNeedComponent,
    DailyCaloricNeedComponent,
    IdealBodyMassComponent,MacronutrientDistributionComponent,
    TargetHeartRateComponent,
    MaincomponentComponent
  ],
  imports: [
    CommonModule,
    HealthCalculationRoutingModule
  ]
})
export class HealthCalculationModule { }
