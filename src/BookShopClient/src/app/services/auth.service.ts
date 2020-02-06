import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  baseUrl: string = "https://localhost:44305/api/auth/";

  constructor(private http: HttpClient) { }

  register(form: FormData){
    return this.http.post(this.baseUrl, form);
  }

  login(form: FormData){
    return this.http.post(this.baseUrl, form);
  }
}
