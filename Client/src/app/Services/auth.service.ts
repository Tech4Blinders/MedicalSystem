import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginDto } from '../_Models/dtos/login.dto';
import { Response } from '../_Models/dtos/responseLogin.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
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

