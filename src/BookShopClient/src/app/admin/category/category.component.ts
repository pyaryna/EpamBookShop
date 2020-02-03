import { Component, OnInit } from '@angular/core';

import { CategoryService } from './category.service';
import { Category } from './category.model';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  categories: Category[];
  addCategoryForm: FormGroup;

  constructor(private service: CategoryService, private fb: FormBuilder,
      private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.addCategoryForm = this.fb.group({
      name:[null, Validators.required]
    })

    this.service.getAllCategories()
    .subscribe((res) => {
      this.categories = res;
    });
  }

  addCategory(){
    let formData = new FormData();

    formData.append("name", this.addCategoryForm.get('name').value);

    this.service.addCategory(formData)
    .subscribe(res =>{
      this.ngOnInit()});
  }

  deleteCategory(id: number){
    if(confirm("Are you sure to delete category with id: " + id)) {
      this.service.deleteCategory(id)
      .subscribe(data =>
        this.ngOnInit());
    }
  }

}
