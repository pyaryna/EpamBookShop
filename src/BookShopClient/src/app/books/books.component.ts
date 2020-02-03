import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { BookService } from '../services/book.service';
import { Book } from '../book/book.model';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {

  books: Book[];

  constructor(private service: BookService, private router: Router) { }

  ngOnInit() {
    this.getAllBooks();
  }

  getAllBooks(): void {
    this.service.getAllBooks()
    .subscribe((res) => {
      this.books = res;
    });
  }

  showBook(id: number){
    this.router.navigate(["/book/" + id]);
  }

  updateBook(id: number){
    this.router.navigate(["/update/" + id]);
  }

  deleteBook(id: number){
    if(confirm("Are you sure to delete book with id: " + id)) {
      this.service.deleteBook(id)
      .subscribe(data =>
        this.ngOnInit());
    }
  }
}
