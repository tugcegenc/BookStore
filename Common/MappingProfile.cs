using AutoMapper;
using WebApi.BookOperations.CeateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book, BookDetailViewModel>().ForMember(dest =>dest.Genre, 
            opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        CreateMap<Book, BookViewModel>().ForMember(dest =>dest.Genre, 
            opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));;
    }
}