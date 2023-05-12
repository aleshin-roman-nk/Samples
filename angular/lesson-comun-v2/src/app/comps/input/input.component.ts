import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent {
  @Output() outEnterName = new EventEmitter<string>()
  
  ngOnInit(): void {
    
  }
  
  enterName(nameInput: HTMLInputElement){
    this.outEnterName.emit(nameInput.value)
    nameInput.value = ""
  }
}
