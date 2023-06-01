
export class Course {
  constructor(
    public id: string = '',
    public name: string = '',
    public startDate: Date = new Date(),
    public duration: number = 0,
    public price: number = 0,
    public maxNumber : number = 0
  ) {}
}