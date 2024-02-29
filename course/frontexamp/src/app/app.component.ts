import { Component } from '@angular/core';
import { MainService } from './services/main.service';
import { Computer } from './data/computer';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontexamp';

  data: Computer[] = []

  loading: boolean = false

  constructor(private service: MainService) {
  }

  ngOnInit(){

    this.loading = true

    this.service.getAll()
    .subscribe(d => {
      this.loading = false
      this.data = d
    })
  }

}
