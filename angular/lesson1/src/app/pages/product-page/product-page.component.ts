import { Component } from '@angular/core';
import { ModalService } from 'src/app/services/modal.service';
import { ProductsService } from 'src/app/services/products.services';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.scss']
})
export class ProductPageComponent {

  ngOnInit(): void {

    this.loading = true

    // this.products$ = this.productService.getAll()
    // .pipe(tap(()=>this.loading = false))

   this.productService.getAll().subscribe(() => {
     this.loading = false
   })

  }

  roman_exp = {ggg: 12}

  title = 'romashka';
  term = ''
  //products: IProduct[] = []
  //products$: Observable<IProduct[]>
  loading = false

constructor(
  public productService: ProductsService,
  public modalService: ModalService
  ){
//console.log(modalService.uid)
}
}
