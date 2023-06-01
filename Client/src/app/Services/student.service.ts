import { Injectable, OnInit } from '@angular/core';
import { Student } from '../_Models/student';

@Injectable({
  providedIn: 'root'
})
export class StudentService implements OnInit{
  studentList : Student[] = [];
  constructor() { }
  ngOnInit(): void {
    this.studentList = [
      new Student('1','Karim Ali','01222868979',''),
      new Student('2','Mohamed Ahmed','01152864479',''),
      new Student('3','Hesham Youssef','01022353979',''),
      new Student('4','Moataz Ahmed','01128446505',''),
      new Student('5','Ahmed Shokry','01062244787',''),
    ]
  }
}
