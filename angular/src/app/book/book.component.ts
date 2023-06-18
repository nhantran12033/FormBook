import { ToasterService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBookService } from '@proxy';
import { BookDto } from '@proxy/books';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {

  Book: BookDto[];
  isModalOpen=false
  constructor(
    private bookService: FormBookService,
    private fb: FormBuilder // inject FormBuilder
  ) { }

  ngOnInit(): void {
    this.bookService.getList().subscribe(response => {
      this.Book = response;
    });
  }
  createBook() {

    this.isModalOpen = true;
  }
}
