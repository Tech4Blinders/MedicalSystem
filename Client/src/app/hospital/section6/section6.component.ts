import { Component } from '@angular/core';
import { Branch } from 'src/app/_Models/dtos/branch';
import { BranchService } from 'src/app/Services/branch.service';

@Component({
  selector: 'app-section6',
  templateUrl: './section6.component.html',
  styleUrls: ['./section6.component.css']
})
export class Section6Component {
  
  branch:Branch;
  
  constructor(private branchServices:BranchService) 
  {
    this.branchServices.getCurrentHospital().subscribe({
      next:(data)=>{
        this.branch=data;
      }
    })  
  }
}
