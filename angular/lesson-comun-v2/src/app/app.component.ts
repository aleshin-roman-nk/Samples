import { Component, OnInit } from '@angular/core';
import { StudentService } from './srv/student.service';
import { Student } from './model';
import { Observable } from 'rxjs';
import { SomeserviceService } from './srv/someservice.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  // $ - по соглашению, чтобы знать, что это Observable
  students$: Observable<Student[]>

iii: number = 189;

  constructor(
    public studentService: StudentService, 
    public someSrv: SomeserviceService){
  }

  ngOnInit(): void {
    this.students$ = this.studentService.students
  }

  addName(name: string){
    this.studentService.addName(name)
  }

}
