import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BookService } from '../services/book.service';

import {
  Router
} from '@angular/router';
import { AuthorService } from '../admin/author/author.service';
import { CategoryService } from '../admin/category/category.service';
import { Author } from '../admin/author/author.model';
import { Category } from '../admin/category/category.model';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})

export class NewBookComponent implements OnInit {

  addBookForm: FormGroup;    
  imageFile: File = null;
  previewUrl;

  authors: Author[];
  categories: Category[];

  constructor(private bookService: BookService, private authorService: AuthorService, private categoryService: CategoryService,
    private fb: FormBuilder, private router: Router) {
      this.getAuthors();
      this.getCategories();
     }

  ngOnInit() {
    this.addBookForm = this.fb.group({
      title:[null, Validators.required],
      language:[null, Validators.required],
      year:[null, Validators.required],
      format:[null, Validators.required],
      cover:[null, Validators.required],
      pagesAmount:[null, Validators.required],
      description:[null, Validators.required],
      price:[null, Validators.required],
      authorId:[null, Validators.required],
      categoryId:[null, Validators.required],
      image:[null, Validators.required]
    });   
  }

  getAuthors(){
    this.authorService.getAllAuthors()
    .subscribe(data =>
      this.authors = data);
  }

  getCategories(){
    this.categoryService.getAllCategories()
    .subscribe(data =>
      this.categories = data);
  }

  uploadFile(event) {    
    
    this.imageFile = (event.target as HTMLInputElement).files[0];

    // this.addBookForm.patchValue({
    //   image: imageFile
    // });
    // this.addBookForm.get('image').updateValueAndValidity()

    this.preview();    
  }
 
  preview() {
    var mimeType = this.imageFile.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }
 
    var reader = new FileReader();      
    reader.readAsDataURL(this.imageFile); 
    reader.onload = (_event) => { 
      this.previewUrl = reader.result; 
    }
  }
   
  onSubmit() {
    let formData = new FormData();

    formData.append("title", this.addBookForm.get('title').value);
    formData.append("language", this.addBookForm.get('language').value);
    formData.append("year", this.addBookForm.get('year').value);
    formData.append("format", this.addBookForm.get('format').value);
    formData.append("cover", this.addBookForm.get('cover').value);
    formData.append("pagesAmount", this.addBookForm.get('pagesAmount').value);
    formData.append("description", this.addBookForm.get('description').value);
    formData.append("price", this.addBookForm.get('price').value);
    formData.append("authorId", this.addBookForm.get('authorId').value);
    formData.append("categoryId", this.addBookForm.get('categoryId').value);
    formData.append("image", this.imageFile);

    this.bookService.addBook(formData)
    .subscribe(res =>{
      this.router.navigate(["/book"])});
  }
}


