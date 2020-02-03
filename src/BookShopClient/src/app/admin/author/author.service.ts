import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Author } from './author.model';

@Injectable({
  providedIn: 'root'
})

export class AuthorService {

  baseUrl: string = "https://localhost:44305/api/author/";

  constructor(private http: HttpClient) { }

  getAllAuthors(){
    return this.http.get<Author[]>(this.baseUrl);
  }

  addAuthor(form: FormData){
      return this.http.post(this.baseUrl, form);
  }

  deleteAuthor(id: number){
    return this.http.delete(this.baseUrl + id);
  }
}
