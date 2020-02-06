import { Book } from 'src/app/book/book.model';
import { Customer } from 'src/app/admin/customer/customer.model';

export interface Order {
    id: number;
    name: string;  
    surName: string;
    phone: string;
    deliver: string;
    customer: Customer;
    DeliverAddress: string;
    dateTime: string;
    totalSum: number;

    books: Book[];  
}