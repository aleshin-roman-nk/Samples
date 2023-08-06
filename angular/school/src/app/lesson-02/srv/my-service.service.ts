import { EventEmitter, Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MyServiceService {

  modalData: EventEmitter<string> = new EventEmitter()

  isOpen$ = new BehaviorSubject<boolean>(false)

  constructor() { }

  openModal(){
    this.isOpen$.next(true)
  }

  closeModal(){
    this.isOpen$.next(false)
  }
}
