import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { ClinicService } from './Services/clinic.service';
import { Clinic } from './_Models/dtos/clinic';

@Injectable({
  providedIn: 'root'
})
export class ClinicGuardGuard implements CanActivate {
  constructor(private clinicService:ClinicService,private router:Router) {
 }
 clinic:Clinic;
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      this.clinicService.getCurrentClinic().subscribe(data=>{
        this.clinic=data;
      })
      console.log(this.clinic);
      if(Object.keys(this.clinic).length == 0)
      {
        this.router.navigate([""]);
        return false;
      }
    return true;
  }
  
}
