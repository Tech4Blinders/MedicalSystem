import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BodyFatCalculationComponent } from './body-fat-calculation/body-fat-calculation.component';

import { BodyMassIndexComponent } from './body-mass-index/body-mass-index.component';
import { IdealBodyMassComponent } from './ideal-body-mass/ideal-body-mass.component';
import { MaincomponentComponent } from './maincomponent/maincomponent.component';

const routes: Routes = [{path:"",component:MaincomponentComponent,children: [
  { path: '', component: BodyFatCalculationComponent },
  { path: 'mass', component: BodyMassIndexComponent },
  { path: 'ideal', component: IdealBodyMassComponent },
],}]



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HealthCalculationRoutingModule { }
