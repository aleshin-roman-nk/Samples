import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable, catchError, tap } from 'rxjs';
import { IProduct } from '../Product';
import { Responce } from '../Responce';

@Injectable({
  providedIn: 'root'
})
export class RomanService {

  private apiUrl = 'https://dummyjson.com';
  private dataSubject: BehaviorSubject<IProduct[]> = new BehaviorSubject<IProduct[]>([]);
  public data$: Observable<IProduct[]> = this.dataSubject.asObservable();

  data123: string[] = ["1", "2"]

  constructor(private http: HttpClient) { }// Сделать все возможные варианты как получать и как хранить полученные с сервера данные

  loadProducts(): void {

    console.log("[loadProducts()] start");

    const url = `${this.apiUrl}/products?limit=10`;

    this.http.get<Responce>(url).subscribe(data => {
      console.log("[loadProducts] This is what we received: ", data)
      this.dataSubject.next(data.products);
    });

    console.log("[loadProducts()] completed");
  }

  createProduct(prod: IProduct): void {
    const url = `${this.apiUrl}/products/add`;

    this.http.post<IProduct>(url, prod)
      .pipe(
        tap(x => {
          console.log("[createProduct] tap")
          console.log(x)

          this.dataSubject.next([...this.dataSubject.value, x]);
        })
      )
      .subscribe()
  }

  getProducts(): Observable<IProduct[]> {

    console.log("enter to getProducts");

    const url = `${this.apiUrl}/products?limit=10`;

    console.log("exit from getProducts");
    return this.http.get<IProduct[]>(url);
  }

  createFetch(prod: IProduct) {
    fetch('https://dummyjson.com/products/add', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(prod)
    })
      .then(res => res.json())
      .then(console.log);
  }

}
