import { Injectable } from '@angular/core';
import { Student } from '../model';
import { BehaviorSubject, Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor() { }

  students: BehaviorSubject<Student[]> = new BehaviorSubject<Student[]>([
    { id: 1, name: 'Ivan' },
    { id: 2, name: 'Bill' },
    { id: 3, name: 'John' },
    { id: 4, name: 'Petr' },
  ])

//В рамках хорошего тона отдельный обзервабле
students$: Observable<Student[]> = this.students.asObservable()

addName(name: string){
this.students$.pipe(take(1)).subscribe((val) =>{
  
  let stdLenght = 0;
  this.students$.subscribe( (students) =>{
    stdLenght = students.length
  })
  
  const newStudent = {
    name: name,
    id: stdLenght + 1
  }

  const newArray = [...val, newStudent];
  this.students.next(newArray);
})}

}
