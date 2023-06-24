import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Environment } from 'src/environment/environment';


@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private googleLoginURL : string = Environment.googleLoginURL;
  constructor(private _httpclient: HttpClient) {}

  public signOutExternal = () => {
    localStorage.removeItem("token");
    console.log("token deleted")
  }

  LoginWithGoogle(credential: string ,role : string ): Observable<any> {
    const header = new HttpHeaders().set('Content-type', 'application/json');
    // return this._httpclient.post(this.googleLoginURL, JSON.stringify({credential:credential,role:role}), { headers: header, withCredentials: true });
    return this._httpclient.post(this.googleLoginURL, JSON.stringify({credential:credential,role:role}), { headers: header });
  }
  register(data: object): Observable<any> {
    return this._httpclient.post('register endpoint', data);
  }
  login(data: object): Observable<any> {
    return this._httpclient.post('login enpoint', data);
  }
}
