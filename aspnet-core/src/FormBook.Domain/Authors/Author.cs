using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FormBook.Authors
{
    public class Author : AuditedAggregateRoot<Guid>
    {
        public string AuthorName { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
    }
}
