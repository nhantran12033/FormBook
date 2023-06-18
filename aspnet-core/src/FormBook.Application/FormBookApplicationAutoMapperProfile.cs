using AutoMapper;
using FormBook.Books;

namespace FormBook;

public class FormBookApplicationAutoMapperProfile : Profile
{
    public FormBookApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookDto>();
    }
}
