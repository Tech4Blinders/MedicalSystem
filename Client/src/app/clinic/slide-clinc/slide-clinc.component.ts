import { Component } from '@angular/core';
import { PhotoService } from 'src/app/Services/photo.service';

@Component({
  selector: 'app-slide-clinc',
  templateUrl: './slide-clinc.component.html',
  styleUrls: ['./slide-clinc.component.css']
})
export class SlideClincComponent {
  constructor(public photoSer: PhotoService) {
    
    
  }

  images: any[] = this.photoSer.getPhotos()
  responsiveOptions: any[] = this.photoSer.getResponsiveOptions();
}
