import { Component, ViewChild } from '@angular/core';
import { ProductsComponent } from './products/products.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'lesson-comun-v3';

  deleteProductA(productsComp: ProductsComponent){
      productsComp.products.pop()
  }

  deleteProductB(){
    this.prodCompVC?.products.pop()
  }

  @ViewChild("prodB") prodCompVC: ProductsComponent | undefined
}
