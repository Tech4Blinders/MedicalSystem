import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginDto } from '../_Models/dtos/login.dto';
import { Response } from '../_Models/dtos/responseLogin.dto';
import { Injectable, OnInit } from '@angular/core';
import {  HttpHeaders } from '@angular/common/http';
import { Environment } from 'src/environment/environment';


@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private googleLoginURL : string = Environment.googleLoginURL;

  public signOutExternal = () => {
    localStorage.removeItem("token");
    console.log("token deleted")
  }

  LoginWithGoogle(credential: string ,role : string ): Observable<any> {
    const header = new HttpHeaders().set('Content-type', 'application/json');
    // return this._httpclient.post(this.googleLoginURL, JSON.stringify({credential:credential,role:role}), { headers: header, withCredentials: true });
    return this._httpclient.post(this.googleLoginURL, JSON.stringify({credential:credential,role:role}), { headers: header });
  }
  public isLogged:BehaviorSubject<boolean>=new BehaviorSubject<boolean>(false);
  constructor(private _httpclient:HttpClient) { }
        apiUrl:string="https://localhost:7025/api/Users/Register"
       register(data:object):Observable<any>
       {
      return this._httpclient.post(this.apiUrl ,data )
       }
       login(data:LoginDto):Observable<any>
       {
        return this._httpclient.post<Response>("https://localhost:7025/api/Users/Login" , data)
       }
       Logging(status:boolean)
       {
        this.isLogged.next(status);
       }
       IsLogged(){
        return this.isLogged.asObservable();
       }
}
