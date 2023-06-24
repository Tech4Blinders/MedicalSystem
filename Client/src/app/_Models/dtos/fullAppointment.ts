
export class FullAppointment {
    id: number;
    appointmentDate: string;
    cost: number;
    doctor?:{
        id: number;
        name: string;
        phoneNumber: string;
        gender: string;
        email: string;
        country: string;
        city: string;
        street: string;
    }
    patient?:{
        name: string;
    phoneNumber: string;
    gender: string;
    age: number;
    email: string;
    id: number;
    }
    branch?:{
        
    id: number;
    name: string;
    phoneNumber: string;
    }
}





  
