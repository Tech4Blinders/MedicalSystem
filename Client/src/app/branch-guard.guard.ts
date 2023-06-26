import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { BranchService } from './Services/branch.service';
import { Branch } from './_Models/dtos/branch';

@Injectable({
  providedIn: 'root'
})
export class BranchGuardGuard implements CanActivate {
  branch:Branch;
  constructor(private branchService:BranchService,private router:Router) {
    
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      this.branchService.getCurrentHospital().subscribe(data=>{
        this.branch=data;
      })
      console.log(this.branch);
      if(Object.keys(this.branch).length == 0)
      {
        this.router.navigate([""]);
        return false;
      }
    return true;
  }
  
}
