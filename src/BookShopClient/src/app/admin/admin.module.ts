import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  RouterModule,
  Routes
} from '@angular/router';

import { AdminComponent } from './admin.component';
import { BooksComponent } from '../books/books.component';
import { AuthorComponent } from './author/author.component';
import { CategoryComponent } from './category/category.component';
import { NewBookComponent } from '../new-book/new-book.component';

export const routes: Routes = [
  { path: '', redirectTo: 'books', pathMatch: 'full' },
  { path: 'books', component: BooksComponent },
  { path: 'newbook', component: NewBookComponent },
  { path: 'authors', component: AuthorComponent },
  { path: 'categories', component: CategoryComponent },
  // { path: 'customers', component: ProductComponent },
  // { path: 'orders', component: ProductComponent }
];

@NgModule({
  declarations: [
    AdminComponent,
    AuthorComponent,
    CategoryComponent
  ],
  exports: [
    AuthorComponent,
    CategoryComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class AdminModule { }
