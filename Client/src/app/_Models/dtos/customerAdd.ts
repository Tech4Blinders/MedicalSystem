export class Customer
{
    email: string;
    name:string;
    creditCard: {
      name: string;
      cardNumber: string;
      expirationYear: string;
      expirationMonth: string;
      cvc: string
    }
  }