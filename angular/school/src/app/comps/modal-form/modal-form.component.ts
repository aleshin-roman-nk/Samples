import { Component, EventEmitter, Output } from '@angular/core';
import { UserResponse } from 'src/app/lesson-01/lesson01-page/model/UserResponse';

@Component({
  selector: 'app-modal-form',
  templateUrl: './modal-form.component.html',
  styleUrls: ['./modal-form.component.css']
})
export class ModalFormComponent {
  formData: { name: string } = { name: '' };

  @Output() finished = new EventEmitter<UserResponse<{name: string}>>()

  refuse() {
    this.finished.emit(new UserResponse({ name: '' }, false))
  }

  submitForm() {
    // Handle form submission
    this.finished.emit(new UserResponse<{name: string}>(this.formData, true))
  }
}
