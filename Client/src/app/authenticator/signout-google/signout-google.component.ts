import { Component, NgZone, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-signout-google',
  templateUrl: './signout-google.component.html',
  styleUrls: ['./signout-google.component.css']
})
export class SignoutGoogleComponent implements OnInit {
  constructor(
    private router:Router,
    private service:AuthService,
    private _ngZone: NgZone
  ){}
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
  public logout() {
    this.service.signOutExternal();
    this._ngZone.run(() => {
      this.router.navigate(['/']).then(() => window.location.reload());
    })
  }
}
