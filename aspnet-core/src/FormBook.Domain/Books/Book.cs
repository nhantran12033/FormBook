
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace FormBook.Books;

public class Book : AuditedAggregateRoot<Guid>
{
    public Guid AuthorId { get; set; }
    public string Name { get; set; }

    public DateTime PublishDate { get; set; }

    public float Price { get; set; }
}
