import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
public isLogged:boolean=false;
constructor(private loggingService:AuthService) {
}
  ngOnInit(): void {
    this.loggingService.IsLogged().subscribe(data=>{
      this.isLogged=data;
    })
  }
  LogOut(){
    localStorage.removeItem("token");
    this.loggingService.Logging(false);
  }

}
