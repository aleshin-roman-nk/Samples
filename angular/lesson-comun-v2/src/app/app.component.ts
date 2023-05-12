import { Component, OnInit } from '@angular/core';
import { StudentService } from './srv/student.service';
import { Student } from './model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  // $ - по соглашению, чтобы знать, что это Observable
  students$: Observable<Student[]>

  constructor(private studentService: StudentService){
  }

  ngOnInit(): void {
    this.students$ = this.studentService.students
  }

  addName(name: string){
    this.studentService.addName(name)
  }

}
