import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SomeserviceService {

  constructor() { }

  myArray: string[] = ["Roman", "Nataly"]

  Ttt(){
    console.log("SomeserviceService")
  }
}
