using FormBook.Books;
using FormBook.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace FormBook
{
    public class FormBookService : ApplicationService, IBookAppService
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Author, Guid> _authorRepository;
        public FormBookService(IRepository<Book, Guid> bookRepository, IRepository<Author, Guid> authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }
        public async Task<List<BookDto>> GetListAsync()
        {
            var items = await _bookRepository.GetListAsync();
            var authors = await _authorRepository.GetListAsync();

            return items.Select(book => new BookDto
            {
                Name = book.Name,
                PublishDate= book.PublishDate,
                Price= book.Price,
                AuthorName = authors.FirstOrDefault(author => author.Id == book.AuthorId)?.AuthorName
            }).ToList();
        }
        public async Task<BookDto> CreateListAsync(BookDto bookDto)
        {
            var items = await _bookRepository.GetListAsync();
            var authors = await _authorRepository.GetListAsync();

            Book book = new Book
            {
                Name = bookDto.Name,
                AuthorId = (Guid)(authors.FirstOrDefault(author => author.AuthorName == bookDto.AuthorName)?.Id),
                Price = bookDto.Price,
                PublishDate = bookDto.PublishDate
            };
            await _bookRepository.InsertAsync(book);

            var createBook = new BookDto
            {
                Name = book.Name,
                PublishDate = book.PublishDate,
                Price = book.Price,
                AuthorName = authors.FirstOrDefault(author => author.Id == book.AuthorId)?.AuthorName
            };
            return createBook;
        }
        public async Task DeleteAsync(Guid Id)
        {
            await _bookRepository.FirstOrDefaultAsync(x => x.Id == id))
            await _bookRepository.DeleteAsync(Id);
        }
    }
}
