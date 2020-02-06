import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  ngOnInit() {
  }

  constructor(private authService: AuthService, fb: FormBuilder, private router: Router) {
    this.registerForm = fb.group({
      'name': ['', Validators.required],
      'email': ['', Validators.required],
      'password': ['', Validators.required],
      'confirmPassword': ['', Validators.required]
    });
  }

  onSubmit() {
    let formData = new FormData();

    formData.append("name", this.registerForm.get('name').value);
    formData.append("email", this.registerForm.get('email').value);
    formData.append("password", this.registerForm.get('password').value);

    this.authService.register(formData)
    .subscribe(res =>{
      this.router.navigate(["/book"])});
  }
}
