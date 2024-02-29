import { Component, Input } from '@angular/core';
import { Computer as IComputer } from 'src/app/data/computer';

@Component({
  selector: 'app-computer',
  templateUrl: './computer.component.html',
  styleUrls: ['./computer.component.css']
})
export class ComputerComponent {
@Input() computer: IComputer | undefined
}
