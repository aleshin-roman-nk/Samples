import { Component, EventEmitter, Output } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-modal-a',
  templateUrl: './modal-a.component.html',
  styleUrls: ['./modal-a.component.css']
})
export class ModalAComponent {
  finished = new EventEmitter<boolean>();
  title!: string;
  message!: string;
  isShown: boolean = false

  closeDialog(answer: boolean) {
    this.isShown = false
    this.finished.emit(answer);
  }

  show(){
    this.isShown = true
  }
}
