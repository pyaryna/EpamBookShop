import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  ngOnInit() {
  }

  constructor(private authService: AuthService, fb: FormBuilder, private router: Router) {
    this.loginForm = fb.group({
      'email': ['', Validators.required],
      'password': ['', Validators.required]
    });
  }

  onSubmit() {
    let formData = new FormData();

    formData.append("email", this.loginForm.get('email').value);
    formData.append("password", this.loginForm.get('password').value);

    this.authService.login(formData)
    .subscribe(res =>{
      this.router.navigate(["/book"])});
  }

}
