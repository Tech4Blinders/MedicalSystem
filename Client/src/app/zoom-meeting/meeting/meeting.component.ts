import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute ,Router} from '@angular/router';

@Component({
  selector: 'app-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.css']
})
export class MeetingComponent {
  private code : string = '';
  constructor (
    private route: ActivatedRoute,
    private http: HttpClient,
    private router:Router
  ) {}

  createMeeting() {
    console.log('byeeeeeee')
    // this.authorize().subscribe((data) => {
    //   console.log(data)
    //   this.code = this.route.snapshot.queryParamMap.get('code');
    //   console.log(this.code);
    // });

    this.router.navigateByUrl('https://zoom.us/oauth/authorize?client_id=75Vsq2TiT8WBkw3Axb7pJA&response_type=code&redirect_uri=https://localhost:4200')
  }
  authorize() {
    const params = {
      client_id:'75Vsq2TiT8WBkw3Axb7pJA',
      response_type:'code',
      redirect_uri:'https://localhost:4200/meeting/test'
  }
    console.log('jjjijwidjwq')
    return this.http.get<any> (
      `https://zoom.us/oauth/authorize`,
      {
        params
      }
    )
  }
}

