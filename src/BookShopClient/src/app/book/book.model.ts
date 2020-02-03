import { Author } from '../admin/author/author.model';
import { Category } from '../admin/category/category.model';

export interface Book {
    id: number;
    title: string;    
    language: string;
    year: number;
    format: string;
    cover: string;
    pagesAmount: number;
    description: string;
    price: number;
    authors:Author[];
    categories:Category[];
    imageUrl: string;
  }