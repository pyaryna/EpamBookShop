import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from './category.model';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {

  baseUrl: string = "https://localhost:44305/api/category/";

  constructor(private http: HttpClient) { }

  getAllCategories() {
    return this.http.get<Category[]>(this.baseUrl);
  }

  addCategory(form: FormData){
      return this.http.post(this.baseUrl, form);
  }

  deleteCategory(id: number){
    return this.http.delete(this.baseUrl + id);
  }
}

