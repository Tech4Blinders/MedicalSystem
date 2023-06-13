import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PhotoService {
  images: any[];
  doctorImgs: any[];
  responsiveOptions: any[];
  constructor() {}
  getPhotos(): any[] {
    this.images = [
      {
        previewImageSrc: '../../../assets/images/hospital.jpg',
        itemImageSrc: '../../../assets/images/hospital.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital.jpg',
        alt: 'Visit',
        title: 'Title 1',
      },
      {
        previewImageSrc: '../../../assets/images/hospital2.jpg',
        itemImageSrc: '../../../assets/images/hospital2.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital2.jpg',
        alt: 'Visit',
        title: 'Title 2',
      },
      {
        previewImageSrc: '../../../assets/images/hospital3.jpg',
        itemImageSrc: '../../../assets/images/hospital3.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital3.jpg',
        alt: 'Visit',
        title: 'Title 3',
      },
      {
        previewImageSrc: '../../../assets/images/hospital4.jpg',
        itemImageSrc: '../../../assets/images/hospital4.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital4.jpg',
        alt: 'Visit',
        title: 'Title 4',
      },
      {
        previewImageSrc: '../../../assets/images/hospital5.jpg',
        itemImageSrc: '../../../assets/images/hospital5.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital5.jpg',
        alt: 'Visit',
        title: 'Title 5',
      },
      {
        previewImageSrc: '../../../assets/images/hospital.jpg',
        itemImageSrc: '../../../assets/images/hospital.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital.jpg',
        alt: 'Visit',
        title: 'Title 6',
      },
      {
        previewImageSrc: '../../../assets/images/hospital.jpg',
        itemImageSrc: '../../../assets/images/hospital.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital.jpg',
        alt: 'Visit',
        title: 'Title 7',
      },
      {
        previewImageSrc: '../../../assets/images/hospital.jpg',
        itemImageSrc: '../../../assets/images/hospital.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital.jpg',
        alt: 'Visit',
        title: 'Title 8',
      },
      {
        previewImageSrc: '../../../assets/images/hospital.jpg',
        itemImageSrc: '../../../assets/images/hospital.jpg',
        thumbnailImageSrc: '../../../assets/images/hospital.jpg',
        alt: 'Visit',
        title: 'Title 9',
      },
    ];
    return this.images;
  }
  getResponsiveOptions(): any[] {
    this.responsiveOptions = [
      {
        breakpoint: '500px',
        numVisible: 2,
      },
    ];
    return this.responsiveOptions;
  }
  getDoctorPhoto() {
    this.doctorImgs = [
      {
        src: '../../assets/images/avatar/doctor-reading-book-white-background.jpg',
      },
      {
        src: '../../assets/images/avatar/handsome-young-doctor-with-lab-coat-stethoscope-using-tablet-computer-check-patient-s-history.jpg',
      },
      {
        src: '../../assets/images/avatar/handsome-young-doctor-with-lab-coat-stethoscope-using-tablet-computer-check-patient-s-history.jpg',
      },
      {
        src: '../../assets/images/avatar/handsome-young-doctor-with-lab-coat-stethoscope-using-tablet-computer-check-patient-s-history.jpg',
      },
      {
        src: '../../assets/images/avatar/handsome-young-doctor-with-lab-coat-stethoscope-using-tablet-computer-check-patient-s-history.jpg',
      },
    ];
    return this.doctorImgs;
  }
}
