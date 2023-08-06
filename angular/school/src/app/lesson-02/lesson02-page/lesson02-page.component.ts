import { Component, OnInit } from '@angular/core';
import { MyServiceService } from '../srv/my-service.service';
import { EditMode } from '../model/editmode';

@Component({
  selector: 'app-lesson02-page',
  templateUrl: './lesson02-page.component.html',
  styleUrls: ['./lesson02-page.component.css']
})
export class Lesson02PageComponent implements OnInit {
  constructor(public mySrv: MyServiceService) {

  }
  ngOnInit(): void {
    this.mySrv.modalData.subscribe(data => {
      console.log("[ngOnInit]", data)
    })
  }

  createUser(data: any){
    console.log("[createUser]", data)
    this.mySrv.closeModal()
  }

  updateUser(data: any){
    console.log("[updateUser]", data)
    this.mySrv.closeModal()
  }

  editMode: EditMode = EditMode.creating

  openCreatingModal(){
    this.editMode = EditMode.creating
    this.mySrv.openModal()
  }

  openUpdatingModal(){
    this.editMode = EditMode.updating
    this.mySrv.openModal()
  }

  closeModal(){
    this.mySrv.closeModal()
  }
}

