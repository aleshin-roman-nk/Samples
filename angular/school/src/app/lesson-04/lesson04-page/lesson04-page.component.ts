import { Component, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ModalComponent } from '../modal/modal.component';
import { ModalAServiceService } from '../services/modal-a-service.service';
import { ModalAComponent } from '../modal-a/modal-a.component';

@Component({
  selector: 'app-lesson04-page',
  templateUrl: './lesson04-page.component.html',
  styleUrls: ['./lesson04-page.component.css']
})
export class Lesson04PageComponent {
  @ViewChild(ModalAComponent, {static: false}) modalA!: ModalAComponent

  /* constructor(private dialog: MatDialog) {} */
  constructor(/* private modalService: ModalAServiceService */) {}


  ngOnInit(){

  }

  ngAfterViewInit(){
    this.modalA.finished.subscribe(data => {
      console.log(data)
    })
  }

  openModal(){
    this.modalA.show()
  }

// using "material"
/*   openModal() {
    const dialogRef = this.dialog.open(ModalComponent, {
      data: { title: 'Modal Title', message: 'Please select an option.' },
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        // Handle 'Yes' answer
        console.log('User clicked "Yes"');
      } else {
        // Handle 'No' answer
        console.log('User clicked "No"');
      }
    });
  } */

// code of programmaticaly creating a component
/*   async openModal() {
    const title = 'Modal Title';
    const message = 'Please select an option.';
    const result = await this.modalService.show(title, message);
    console.log('Modal result:', result);
  } */

}
