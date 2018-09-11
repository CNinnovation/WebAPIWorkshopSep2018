import { FormsModule} from '@angular/forms';
import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
  public books: Book[];
  private newbook: Book = new Book();
  public title: string;
  public publisher: string;
  public postcomplete: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { 
    http.get<Book[]>(baseUrl + '/api/Books').subscribe(result => {
      this.books = result;
    })
  }

  ngOnInit() {
  }

  addbook() {
    this.newbook.title = this.title;
    this.newbook.publisher = this.publisher;
    this.http.post(this.baseUrl + '/api/Books', this.newbook).subscribe(result => {
      this.postcomplete = true;
    });
  }

}

class Book {
  bookId : number;
  title: string;
  publisher: string;
}
