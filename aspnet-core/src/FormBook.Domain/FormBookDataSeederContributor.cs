using System;
using System.Threading.Tasks;
using FormBook.Authors;
using FormBook.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.OpenIddict.Authorizations;
using Volo.Abp.Security.Encryption;

namespace FormBook;

public class FormBookDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly IRepository<Author, Guid> _authorRepository;


    public FormBookDataSeederContributor(IRepository<Book, Guid> bookRepository,
        IRepository<Author, Guid> authorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;

    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _bookRepository.GetCountAsync() > 0)
        {
            return;
        }
        var orwell = await _authorRepository.InsertAsync(
                new Author {
                    AuthorName ="George Orwell",
                    Birth=new DateTime(1903, 06, 25),
                    Address="20 Washington"

                },
                autoSave: true
            );
            var douglas = await _authorRepository.InsertAsync(
               new Author
               {
                   AuthorName = "Douglas Adams",
                   Birth = new DateTime(1952, 03, 11),
                   Address = "25 U.S"

               },
                autoSave: true
            );
            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = orwell.Id,
                    Name = "1984",
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = douglas.Id,
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );
        }
    
}
