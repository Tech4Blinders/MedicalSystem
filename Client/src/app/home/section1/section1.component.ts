import { Component } from '@angular/core';
import { PhotoService } from 'src/app/Services/photo.service';

@Component({
  selector: 'app-section1',
  templateUrl: './section1.component.html',
  styleUrls: ['./section1.component.css'],
})
export class Section1Component {
  id: string = '1';

  constructor(private Photo: PhotoService) {}

  images: any[] = this.Photo.getPhotos();
  responsiveOptions: any[] = this.Photo.getResponsiveOptions();
}
