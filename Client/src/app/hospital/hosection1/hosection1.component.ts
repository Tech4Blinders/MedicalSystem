import { Component } from '@angular/core';
import { BranchService } from 'src/app/Services/branch.service';
import { Branch } from 'src/app/_Models/dtos/branch';

@Component({
  selector: 'app-hosection1',
  templateUrl: './hosection1.component.html',
  styleUrls: ['./hosection1.component.css']
})
export class Hosection1Component {
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
