import type { BookDto } from './books/models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class FormBookService {
  apiName = 'Default';
  

  createList = (bookDto: BookDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookDto>({
      method: 'POST',
      url: '/api/app/form-book/list',
      body: bookDto,
    },
    { apiName: this.apiName,...config });
  

  delete = (Id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: '/api/app/form-book',
      params: { id: Id },
    },
    { apiName: this.apiName,...config });
  

  getList = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, BookDto[]>({
      method: 'GET',
      url: '/api/app/form-book',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
