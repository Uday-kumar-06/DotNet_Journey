import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseListComponent } from './course-list/course-list';
import { CourseDetailComponent } from './course-detail/course-detail';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    CourseListComponent,
    CourseDetailComponent
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  courses = [
    {
      id: 1,
      title: 'Angular Basics',
      description: 'Learn Angular Fundamentals'
    },
    {
      id: 2,
      title: 'Java Programming',
      description: 'Core and Advanced Java'
    },
    {
      id: 3,
      title: 'Web Development',
      description: 'HTML CSS JavaScript'
    }
  ];

  selectedCourse = this.courses[0];

  selectCourse(course:any){
    this.selectedCourse = course;
  }
}