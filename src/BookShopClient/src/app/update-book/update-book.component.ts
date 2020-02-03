import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../services/book.service';
import { Book } from '../book/book.model';
import { Author } from '../admin/author/author.model';
import { Category } from '../admin/category/category.model';
import { AuthorService } from '../admin/author/author.service';
import { CategoryService } from '../admin/category/category.service';

@Component({
  selector: 'app-update-book',
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})

export class UpdateBookComponent implements OnInit {

  book: Book;
  updateBookForm: FormGroup;    
  imageFile: File = null;
  previewUrl;

  authors: Author[];
  categories: Category[];

  constructor(private service: BookService, private authorService: AuthorService, private categoryService: CategoryService,
    private fb: FormBuilder, private route: ActivatedRoute, private router: Router) { 
      this.getAuthors();
      this.getCategories();
    }

  ngOnInit() {
    this.service.getBookById(this.route.snapshot.params.id)
    .subscribe(data => {
      this.book = data;
      this.updateBookForm = this.fb.group({
        id:[data.id],
        title:[data.title, Validators.required],
        language:[data.language, Validators.required],
        year:[data.year, Validators.required],
        format:[data.format, Validators.required],
        cover:[data.cover, Validators.required],
        pagesAmount:[data.pagesAmount, Validators.required],
        description:[data.description, Validators.required],
        price:[data.price, Validators.required],
        authorId:[data.authors[0].name, Validators.required],
        categoryId:[data.categories[0].name, Validators.required],
        image:[null]
      });  
      this.updateBookForm.get('authorId').setValue(data.authors[0].name, {onlySelf: true});
      this.updateBookForm.controls['categoryId'].setValue(data.categories[0].name, {onlySelf: true});
      this.previewOld(data.imageUrl);
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
    this.previewNew();    
  }
 
  previewNew() {
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

  previewOld(imageUrl: string) {
    this.previewUrl = "assets"+imageUrl.substr(1); 
  }
   
  onSubmit() {
    let formData = new FormData();

    formData.append("id", this.updateBookForm.get('id').value);
    formData.append("title", this.updateBookForm.get('title').value);
    formData.append("language", this.updateBookForm.get('language').value);
    formData.append("year", this.updateBookForm.get('year').value);
    formData.append("format", this.updateBookForm.get('format').value);
    formData.append("cover", this.updateBookForm.get('cover').value);
    formData.append("pagesAmount", this.updateBookForm.get('pagesAmount').value);
    formData.append("description", this.updateBookForm.get('description').value);
    formData.append("price", this.updateBookForm.get('price').value);
    formData.append("authorId", this.updateBookForm.get('authorId').value);
    formData.append("categoryId", this.updateBookForm.get('categoryId').value);
    formData.append("existingImagePath", this.book.imageUrl);
    formData.append("image", this.imageFile);

    this.service.updateBook(this.book.id, formData)
    .subscribe(res =>{
      this.router.navigate(["/book/" + this.book.id])});
  }  

}
