import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HospitalComponent } from './hospital.component';
import { BranchGuardGuard } from '../branch-guard.guard';

const routes: Routes = [
  { path: '', component: HospitalComponent,canActivate:[BranchGuardGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class HospitalRoutingModule {}
