import { Component, EventEmitter, Input, Output } from '@angular/core';
import { EditMode } from '../../model/editmode';

@Component({
  selector: 'app-user-input1',
  templateUrl: './user-input1.component.html',
  styleUrls: ['./user-input1.component.css']
})
export class UserInput1Component {
  @Output() createUser: EventEmitter<any> = new EventEmitter();
  @Output() updateUser: EventEmitter<any> = new EventEmitter();
  @Input() editMode: EditMode = EditMode.creating

  usingEditState = EditMode

  username: string = ""
  submitForm() {

    if (this.editMode === EditMode.creating)
    {
      const formData = {
        state: "creating",
        username: this.username
      };
      this.createUser.emit(formData)
    }
    else
    {
      const formData = {
        state: "updating",
        username: this.username
      };
      this.updateUser.emit(formData)
    }
  }
}
