import type { AuditedEntityDto } from '@abp/ng.core';

export interface BookDto extends AuditedEntityDto<string> {
  name?: string;
  authorName?: string;
  publishDate?: string;
  price: number;
}
