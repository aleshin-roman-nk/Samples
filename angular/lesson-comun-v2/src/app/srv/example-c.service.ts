import { Injectable } from '@angular/core';
import { ObjectB } from './objectB';
import { BehaviorSubject, Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExampleCService {

  constructor() { }

  run1() {

    const subject1 = new Subject();
    subject1.subscribe(x => console.log(x));
    subject1.next(1);

  }

  run2() {
    const subject = new Subject();

    subject.subscribe((value) => console.log(value));
    subject.subscribe((value) => console.log(value));
    subject.subscribe((value) => console.log(value));

    subject.next('some value');
  }

  run3() {
    const observable = new Observable((observer) => {
      observer.next('some value');
   });
  }

  observable$ = new Observable<string>((obs) => {
    obs.next('some operation')
  })

  operation(): Observable<string> {
    return this.observable$
  }

  run() {
    const subject = new BehaviorSubject(123);

    // two new subscribers will get initial value => output: 123, 123
    subject.subscribe(x => { console.log("I am A", x) });
    subject.subscribe(x => { console.log("I am B", x) });

    // two subscribers will get new value => output: 456, 456
    subject.next(456);

    // new subscriber will get latest value (456) => output: 456
    subject.subscribe(x => { console.log("I am C", x) });

    // all three subscribers will get new value => output: 789, 789, 789
    subject.next(789);

    // output: 123, 123, 456, 456, 456, 789, 789, 789
  }
}
