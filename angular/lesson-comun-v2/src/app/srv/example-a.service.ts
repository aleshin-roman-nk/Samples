import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExampleAService {

  beSubject = new BehaviorSubject('a');

  constructor() { }

  run(){
    this.beSubject.next('b');

    this.beSubject.subscribe(value => {
      console.log('Subscription received the value ', value);

      // Subscription received B. It would not happen
      // for an Observable or Subject by default.
    });

    this.beSubject.next('c');
    // Subscription received C.

    this.beSubject.next('d');
    // Subscription received D.
  }

}
