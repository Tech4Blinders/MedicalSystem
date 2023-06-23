export class MeetingJoinData
{
    constructor(
    public id : number = 0,
    public meetingId : string = '',
    public password:string = '',
    public startTime: string = '',
    public duration:number=0
  ) {}

}
// {
//   "id": 21,
//   "meetingId": "83824474538",
//   "password": "123",
//   "startTime": "2023-06-23T23:25:13",
//   "duration": 60
// }
