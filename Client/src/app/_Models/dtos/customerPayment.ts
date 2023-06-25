export class CustomerPayment{
    constructor(
    public customerId:string,
    public receiptEmail: string,
    public description: string,
    public currency: string,
    public amount: number)
    {}
        
    }    
    
