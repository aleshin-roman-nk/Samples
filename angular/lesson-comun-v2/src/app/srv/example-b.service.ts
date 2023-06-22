import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { ObjectB } from './objectB';

@Injectable({
  providedIn: 'root'
})
export class ExampleBService {

  private dataSubject: BehaviorSubject<ObjectB>;
  public data$: Observable<ObjectB>;

  constructor()
  {
    this.dataSubject = new BehaviorSubject<ObjectB>({name: "start", age: 0})
    this.data$ = this.dataSubject.asObservable()
  }

  run() {
    const newObj = this.dataSubject.getValue()
    newObj.age += 20
    this.dataSubject.next(newObj)
  }
}
