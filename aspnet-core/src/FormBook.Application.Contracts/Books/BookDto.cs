﻿using System;
using Volo.Abp.Application.Dtos;

namespace FormBook.Books;

public class BookDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }

    public string AuthorName { get; set; }
    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
}
