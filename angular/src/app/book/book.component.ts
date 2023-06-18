import { ListService } from '@abp/ng.core'
import { ToasterService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBookService } from '@proxy';
import { BookDto } from '@proxy/books';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
  providers: [
    ListService,
    { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }
  ],


})
export class BookComponent implements OnInit {
  form: FormGroup;
  Book: BookDto[];
  isModalOpen = false;
  constructor(
    public readonly list: ListService,
    private bookService: FormBookService,
    private fb: FormBuilder,
    private toasterService: ToasterService,
    private confirmation: ConfirmationService
  ) { }

  ngOnInit(): void {
    this.bookService.getList().subscribe(response => {
      this.Book = response;
    });
  }
  createBook() {
    this.buildForm();
    this.isModalOpen = true;
  }
  buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      authorName: ['', Validators.required],
      publishDate: [null, Validators.required],
      price: [null, Validators.required],
    })
  }
  save() {
    try {
      if (this.form.invalid) {
        return;
      }
      this.bookService.createList(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
        this.ngOnInit();
      });
    }
    catch {
      this.toasterService.info('Error.');
    }

  }
  delete(id: string) {
    this.confirmation.warn('::Are you sure to delete ?', '::AreYouSure').subscribe((status) => {
      if (status === Confirmation.Status.confirm) {
        this.bookService.delete(id).subscribe(() => {
          this.form.reset();
          this.list.get();
          this.ngOnInit();
        });
      }
    });
  }
}
