import { Component, OnInit } from '@angular/core';
import { StudentService } from './srv/student.service';
import { Student } from './model';
import { Observable } from 'rxjs';
import { SomeserviceService } from './srv/someservice.service';
import { RomanService } from './srv/roman.service';
import { ExampleAService } from './srv/example-a.service';
import { ExampleBService } from './srv/example-b.service';
import { ExampleCService } from './srv/example-c.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  // $ - по соглашению, чтобы знать, что это Observable
  //students$: Observable<Student[]>

//iii: number = 189;

  constructor(
    public studentService: StudentService,
    public someSrv: SomeserviceService,
    public romanSrv: RomanService,
    public exampleASrv: ExampleAService,
    public exampleBSrv: ExampleBService,
    public exampleCSrv: ExampleCService){
  }

  ngOnInit(): void {
    console.log("[ngOnInit()] start")

/*     console.log("[ngOnInit()] calling this.romanSrv.data$.subscribe...")
    this.romanSrv.data$.subscribe(prod =>{
      console.log("[ngOnInit()] [data$.subscribe] received data:", prod)
    }) */

    this.romanSrv.loadProducts()

/*     console.log("calling this.romanSrv.getProducts()...")
    this.romanSrv.getProductsA().subscribe(data => {
      console.log(data)
    }) */

    this.exampleCSrv.operation().subscribe(v => {
      console.log(v, "subscriber")
    })

    this.exampleCSrv.observable$.subscribe(v => {
      console.log("direct subscr", v)
    })

    console.log("[ngOnInit()] completed")
  }

  oper() {
    this.exampleCSrv.operation().subscribe(v => {
      console.log(v)
    })
  }

  reloadProducte(): void{
    console.log("[reloadProducte] start")
    this.romanSrv.loadProducts()
    console.log("[reloadProducte] completed")
  }

  addN(){
    this.romanSrv.data123.push("123");
  }

  addName(name: string){
    //this.studentService.addName(name)
  }

  create(): void {

    console.log("[create()]")

    this.romanSrv.createProduct({
      title: "Roman A",
      id: 0,
      description: '',
      price: 0,
      discountPercentage: 0,
      rating: 0,
      stock: 0,
      brand: '',
      category: '',
      images: []
    })

    console.log("[create()] completed")
  }

  createFetch(){
    this.romanSrv.createFetch({
      title: "Roman A with fetch",
      id: 0,
      description: '',
      price: 0,
      discountPercentage: 0,
      rating: 0,
      stock: 0,
      brand: '',
      category: '',
      images: []
    })
  }
}
