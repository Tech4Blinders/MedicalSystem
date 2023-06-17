import { Component } from '@angular/core';
import { PhotoService } from 'src/app/Services/photo.service';

@Component({
  selector: 'app-card-section',
  templateUrl: './card-section.component.html',
  styleUrls: ['./card-section.component.css']
})
export class CardSectionComponent {

constructor(public cardImg: PhotoService) {}

images: any[] = this.cardImg.getClinicImgs();
}
