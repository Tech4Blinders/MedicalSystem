import { Component, Input } from '@angular/core';
import { DashboardDataService } from '../dashboard-data.service';
import { FormGroup,FormControl,Validators} from '@angular/forms'

@Component({
  selector: 'app-dashboard-home',
  templateUrl: './dashboard-home.component.html',
  styleUrls: ['./dashboard-home.component.css']
})
export class DashboardHomeComponent {
  @Input()
  addFlag: Boolean=false;


  addDoc(){
    this.addFlag=true;
  }

  //changing value coming from child
  changeFlag(value:any){
    this.addFlag=value;
  }
}
