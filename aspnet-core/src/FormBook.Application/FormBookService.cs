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
            var book = ObjectMapper.Map<BookDto, Book>(bookDto);
            await _bookRepository.InsertAsync(book);
            return ObjectMapper.Map<Book, BookDto>(book);
        }
    }
}
