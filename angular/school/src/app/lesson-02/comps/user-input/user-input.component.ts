import { Component, EventEmitter, Output } from '@angular/core';
import { MyServiceService } from '../../srv/my-service.service';

@Component({
  selector: 'app-user-input',
  templateUrl: './user-input.component.html',
  styleUrls: ['./user-input.component.css']
})
export class UserInputComponent {

  

  constructor(private mySrv: MyServiceService) {

  }

  username: string = ""

  submitForm() {
    const formData = {
      username: this.username
    };

    this.mySrv.modalData.emit(formData.username)
    this.mySrv.closeModal()
  }
}
