import { Component } from '@angular/core';
import { FormControl , FormGroup , Validators } from '@angular/forms';
import { PaymentService } from 'src/app/Services/payment.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
  constructor(private _payment:PaymentService ) {
       
  }
    paymentform= new FormGroup({

       email:new FormControl(null, [Validators.email,Validators.required]) ,
       name:new FormControl(null, [Validators.minLength(3),Validators.required]) ,
       creditCard:new FormGroup({
        name:new FormControl(null) ,
        cardNumber:new FormControl(null) , 
        expirationYear:new FormControl(null) , 
        expirationMonth:new FormControl(null) , 
        cvc:new FormControl(null), 

       })

   })
   handlepayment(paymentform:FormGroup)
   {
     
      if(paymentform.valid)
      {
          console.log(paymentform.value);
         this._payment.checkout(paymentform.value).subscribe({
          next:(response)=>{
            console.log(response);//cutomer id
           
          } , 
          
          
         });
      }
      
   } 

}
