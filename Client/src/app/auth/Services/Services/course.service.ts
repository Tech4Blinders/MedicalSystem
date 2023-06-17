import { Injectable, OnInit } from '@angular/core';
import { Course } from '../../../_Models/course';

@Injectable({
  providedIn: 'root'
})
export class CourseService implements OnInit {
  coursesList : Course[] = []
  constructor() { }
  ngOnInit(): void {
    this.coursesList = [
      new Course('1','Javascript',new Date("2023-01-16"),3,2000,50),
      new Course('1','Javascript',new Date("2023-01-16"),3,2000,50),
      new Course('1','Javascript',new Date("2023-01-16"),3,2000,50),
      new Course('1','Javascript',new Date("2023-01-16"),3,2000,50),
      new Course('1','Javascript',new Date("2023-01-16"),3,2000,50),
    ]
  }
}
