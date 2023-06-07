import { Injectable } from '@angular/core';
import { Student } from '../model';
import { BehaviorSubject, Observable, from, of, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor() { }

  studentsArr: Student[] = [
    { id: 1, name: 'Ivan' },
    { id: 2, name: 'Bill' },
    { id: 3, name: 'John' },
    { id: 4, name: 'Petr' },
  ]

  students: BehaviorSubject<Student[]> = new BehaviorSubject<Student[]>([
    { id: 1, name: 'Ivan' },
    { id: 2, name: 'Bill' },
    { id: 3, name: 'John' },
    { id: 4, name: 'Petr' },
  ])

  //В рамках хорошего тона отдельный Observable
  students$: Observable<Student[]> = this.students.asObservable()

  stream$ = of(1, 2, 3, 4, 5)
  streamStud$ = from(this.studentsArr)

  stream2$ = of([
    { id: 1, name: 'Ivan' },
    { id: 2, name: 'Bill' },
    { id: 3, name: 'John' },
    { id: 4, name: 'Petr' },
  ],
  [
    { id: 1, name: 'Ivan1' },
    { id: 2, name: 'Bill1' },
    { id: 3, name: 'John1' },
    { id: 4, name: 'Petr1' },
  ],
  [
    { id: 1, name: 'Ivan2' },
    { id: 2, name: 'Bill2' },
    { id: 3, name: 'John2' },
    { id: 4, name: 'Petr2' },
  ]
  )

  //streamStud1$ = new Observable<Student[]>(this.studentsArr)


  ttt(){
/*     this.students$.pipe(take(3)).subscribe({
      next: v => {let i = 0; console.log(v[i].name); i++}
    }) */

    let i: number = 0;
/*     this.stream$.pipe(take(3)).subscribe(val => {
      console.log(`Value ${i} :`, val)
      i++;
    }) */

    this.stream2$.pipe(take(3)).subscribe(val => {
      console.log(val)
    })

  }

  addName(name: string) {

    let i: number = 0;

    // После того как выполнена операция pipe(take(1)) мы можем подписаться по окончании ее выполнения и подписаться чтобы обработать результат
    this.students$.pipe(take(2)).subscribe((val) => {

      console.log(val[i].name);
      console.log(i);
      i++;

/*       let stdLenght = 0;
      this.students$.subscribe((students) => {
        stdLenght = students.length
      })

      const newStudent = {
        name: name,
        id: stdLenght + 1
      }

      const newArray = [...val, newStudent];
      this.students.next(newArray); */
    })

  }

}
