import { Component, Input } from '@angular/core';
import { Student } from 'src/app/model';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {
@Input() student: Student
}
