import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _httpclient:HttpClient) { }
        
       register(data:object):Observable<any>
       {
      return this._httpclient.post('register endpoint' ,data )
       }
       login(data:object):Observable<any>
       {
        return this._httpclient.post('login enpoint' , data)
       }
}

