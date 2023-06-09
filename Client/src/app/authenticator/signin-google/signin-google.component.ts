import { Component, OnInit, NgZone } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';
import { AuthService } from 'src/app/Services/auth.service';
import { PatientService } from 'src/app/Services/patient.service';
import { Response } from 'src/app/_Models/dtos/responseLogin.dto';
import { Environment } from 'src/environment/environment';
@Component({
  selector: 'app-signin-google',
  templateUrl: './signin-google.component.html',
  styleUrls: ['./signin-google.component.css'],
})
export class SigninGoogleComponent implements OnInit {
  googleClientId : string = Environment.googleClientId;
  // googleLoginURL : string = Environment.googleLoginURL;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private service: AuthService,
    private _ngZone: NgZone,
    private patientService:PatientService,
    private loginService:AuthService
  ) {}

  ngOnInit() {
    // @ts-ignore
    window.onGoogleLibraryLoad = () => {
      // @ts-ignore
      google.accounts.id.initialize({
        client_id: this.googleClientId,
        // login_uri: this.googleLoginURL,
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true,
      });
      // @ts-ignore
      google.accounts.id.renderButton(
        // @ts-ignore
        document.getElementById('buttonDiv'),
        { theme: 'outline', size: 'large', width: 100 }
      );
      // @ts-ignore
      google.accounts.id.prompt((notification: PromptMomentNotification) => {});
    };
  }

  async handleCredentialResponse(response: CredentialResponse) {
    await this.service.LoginWithGoogle(response.credential,'Patient').subscribe( //==> will hit our backend authentication api to get the token
      (x:Response) => {
        console.log(x)
        localStorage.setItem("token",x.token);
        this.patientService.getPatient(x.id).subscribe(data=>{
          this.patientService.setPatient(data);
          this.loginService.Logging(true);
          
        })
        
        this._ngZone.run(() => {
          this.router.navigate(['/']);
        })},
      (error:any) => {
          console.log(error);
        }
      );
  }
}
