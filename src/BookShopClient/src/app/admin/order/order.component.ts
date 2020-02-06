import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Order } from './order.model';
import { OrderService } from './order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  orders: Order[];

  constructor(private service: OrderService,
      private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.service.getAllOrders()
    .subscribe((res) => {
      this.orders = res;
    });
  }

  deleteCategory(id: number){
    if(confirm("Are you sure to delete category with id: " + id)) {
      this.service.deleteOrder(id)
      .subscribe(data =>
        this.ngOnInit());
    }
  }

}