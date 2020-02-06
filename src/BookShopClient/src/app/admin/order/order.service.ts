import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from './order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  
  baseUrl: string = "https://localhost:44305/api/order/";

  constructor(private http: HttpClient) { }

  getAllOrders() {
    return this.http.get<Order[]>(this.baseUrl);
  }

  deleteOrder(id: number){
    return this.http.delete(this.baseUrl + id);
  }
}
