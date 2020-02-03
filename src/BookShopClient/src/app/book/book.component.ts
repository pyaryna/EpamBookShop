import { Component, OnInit } from '@angular/core';

import { BookService } from '../services/book.service';
import { Book } from '../book/book.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  book: Book;

  constructor(private service: BookService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.service.getBookById(this.route.snapshot.params.id)
    .subscribe((res) => {
      this.book = res;
    });
  }

  updateBook(id: number){
    this.router.navigate(["/update/" + id]);
  }

  deleteBook(id: number){
    if(confirm("Are you sure to delete book with id: " + id)) {
      this.service.deleteBook(id)
      .subscribe(data =>
        this.router.navigate(["/book"]));
    }
  }
}
