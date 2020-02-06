import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { CustomerService } from './customer.service';
import { Customer } from './customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customers: Customer[];

  constructor(private service: CustomerService,
      private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.service.getAllCustomers()
    .subscribe((res) => {
      this.customers = res;
    });
  }

  deleteCategory(id: number){
    if(confirm("Are you sure to delete category with id: " + id)) {
      this.service.deleteCustomer(id)
      .subscribe(data =>
        this.ngOnInit());
    }
  }

}
