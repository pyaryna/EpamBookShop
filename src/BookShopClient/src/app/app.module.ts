import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import {
  RouterModule,
  Routes
} from '@angular/router';

import {
  routes as childRoutes,
  AdminModule
} from './admin/admin.module';

import { AdminComponent } from './admin/admin.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { BookComponent } from './book/book.component';
import { BooksComponent } from './books/books.component';
import { RegisterComponent } from './register/register.component';
import { NewBookComponent } from './new-book/new-book.component';
import { UpdateBookComponent } from './update-book/update-book.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: '', redirectTo: 'book', pathMatch: 'full' },
  { path: 'home', redirectTo: 'book', pathMatch: 'full' },
  { path: 'book', component: BooksComponent },
  { path: 'book/:id', component: BookComponent },
  { path: 'update/:id', component: UpdateBookComponent },
  { path: 'newbook', component: NewBookComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'cart', component: CartComponent },

  {
    path: 'admin',
    component: AdminComponent,
    children: childRoutes
  }
];

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    BookComponent,
    BooksComponent,
    RegisterComponent,
    NewBookComponent,
    UpdateBookComponent,
    CartComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),

    AdminModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
