import { Component, Input } from '@angular/core';
import { ObjectB } from 'src/app/srv/objectB';

@Component({
  selector: 'app-example-b',
  templateUrl: './example-b.component.html',
  styleUrls: ['./example-b.component.css']
})
export class ExampleBComponent {
@Input() objectB: ObjectB | null
}
