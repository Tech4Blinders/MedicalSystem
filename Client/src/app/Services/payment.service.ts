import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerPayment } from '../_Models/dtos/customerPayment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  constructor(private _httpclient:HttpClient) { }

   checkout(customercardobject:any ):Observable<any>
   {
        console.log(customercardobject);
    return this._httpclient.post('https://localhost:7025/api/AddStripe/customer/add ',customercardobject);
    
   }
   pay(customerPayment:CustomerPayment)
   {
    return this._httpclient.post<CustomerPayment>('https://localhost:7025/api/AddStripe/payment/add',customerPayment);
   }
}
