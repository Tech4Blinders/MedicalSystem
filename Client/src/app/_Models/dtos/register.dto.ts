

export class RegisterDto {
    
    name: string;
    userName: string;
    email: string;
    password: string;
    phoneNumber: string;
    role: string;
    gender?: string;
    age?: number;
    country?: string;
    city?: string;
    street?: string;
    departmentId?: number;
    clinicId?: number;
    offlineCost?: number;
    onlineCost?: number;
    file?: File;
}