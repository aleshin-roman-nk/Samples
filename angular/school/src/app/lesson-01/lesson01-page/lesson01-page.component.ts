import { Component } from '@angular/core';
import { UserResponse } from './model/UserResponse';

@Component({
  selector: 'app-lesson01-page',
  templateUrl: './lesson01-page.component.html',
  styleUrls: ['./lesson01-page.component.css']
})
export class Lesson01PageComponent {
  isModalOpen = false;

  user: { name: string } = { name : '' }
  userName: string = ""

  Finished(eventdata: UserResponse<{name: string}>){
    if(eventdata.hasUserAccepted)
      console.log(eventdata)
    this.isModalOpen = false
    this.user = eventdata.value
    this.userName = this.user.name
  }

  openModal(){
    this.isModalOpen = true
  }
}
