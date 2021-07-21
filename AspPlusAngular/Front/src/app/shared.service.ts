import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl="http://localhost:5000/api";
  constructor(private http:HttpClient) { }

  getCustomerList():Observable<any[]>
  {
    return this.http.get<any>(this.APIUrl+ '/Customer');
  }

  addNewCustomer(val:any)
  {
    return this.http.post(this.APIUrl + '/Customer',val);
  }
}
