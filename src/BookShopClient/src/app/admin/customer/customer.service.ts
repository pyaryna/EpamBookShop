import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Customer } from './customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  
  baseUrl: string = "https://localhost:44305/api/customer/";

  constructor(private http: HttpClient) { }

  getAllCustomers() {
    return this.http.get<Customer[]>(this.baseUrl);
  }

  deleteCustomer(id: number){
    return this.http.delete(this.baseUrl + id);
  }
}
