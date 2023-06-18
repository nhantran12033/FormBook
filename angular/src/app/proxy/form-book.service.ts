import type { BookDto } from './books/models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FormBookService {
  apiName = 'Default';
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookDto[]>({
      method: 'GET',
      url: '/api/app/form-book',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
