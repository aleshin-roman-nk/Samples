import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment';
import { Computer } from '../data/computer';

@Injectable({
  providedIn: 'root'
})
export class MainService {
  
  constructor(private http: HttpClient) {
    
   }

   getAll(): Observable<Computer[]>{
    //const url = `${environment.apiUrlDebug}/Computers`
    const url = `${environment.apiUrl}/Computers`
    //const url = `${environment.apiUrlDebugLocal}/Computers`
    //const url = `${environment.apiUrlDebugLocalInDocker}/Computers `
    return this.http
    .get<Computer[]>(url)
  }

}