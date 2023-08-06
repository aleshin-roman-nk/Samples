import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserResponse } from 'src/app/lesson-01/lesson01-page/model/UserResponse';

@Component({
  selector: 'app-modal-form-a',
  templateUrl: './modal-form-a.component.html',
  styleUrls: ['./modal-form-a.component.css']
})
export class ModalFormAComponent {
  @Input() formData!: { name: string; };

  @Output() finished = new EventEmitter<UserResponse<{name: string}>>()

  ngOnInit(){
    console.log(this.formData)
  }

  ngOnDestroy(){
    console.log("ngOnDestroy", this.formData)
  }

  refuse() {
    this.finished.emit(new UserResponse(this.formData, false))
  }

  submitForm() {
    // Handle form submission
    this.finished.emit(new UserResponse<{name: string}>(this.formData, true))
  }
}
