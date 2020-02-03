import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Book } from '../book/book.model';

@Injectable({
  providedIn: 'root'
})

export class BookService {

  baseUrl: string = "https://localhost:44305/api/book/";

  constructor(private http: HttpClient) { }

  getAllBooks() {
    return this.http.get<Book[]>(this.baseUrl);
  }

  addBook(form: FormData){
      return this.http.post(this.baseUrl, form);
  }

  getBookById(id: number){
    return this.http.get<Book>(this.baseUrl + id);
  }

  updateBook(id: number, form: FormData){
    return this.http.put(this.baseUrl + id, form);
  }

  deleteBook(id: number){
    return this.http.delete(this.baseUrl + id);
  }
}
