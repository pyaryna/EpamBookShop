import { Component, OnInit } from '@angular/core';

import { AuthorService } from './author.service';
import { Author } from './author.model';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {

  authors: Author[];
  addAuthorForm: FormGroup;

  constructor(private service: AuthorService, private fb: FormBuilder,
      private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.addAuthorForm = this.fb.group({
      name:[null, Validators.required]
    })

    this.service.getAllAuthors()
    .subscribe((res) => {
      this.authors = res;
    });
  }

  addAuthor(){
    let formData = new FormData();

    formData.append("name", this.addAuthorForm.get('name').value);

    this.service.addAuthor(formData)
    .subscribe(res =>{
      this.ngOnInit()});
  }

  deleteAuthor(id: number){
    if(confirm("Are you sure to delete author with id: " + id)) {
      this.service.deleteAuthor(id)
      .subscribe(data =>
        this.ngOnInit());
    }
  }
}
