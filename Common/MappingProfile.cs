using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries;
using WebApi.Application.GenreOperations.Querie.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookModel, Book>();

        CreateMap<Book, BookDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));

        CreateMap<Book, BookViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.FirstName + " " + src.Author.LastName));

        CreateMap<Genre, GenreDetailViewModel>();
        CreateMap<Genre, GenresViewModel>();

        CreateMap<Author, AuthorViewModel>();
        CreateMap<Author, GetAuthorDetailQuery.AuthorDetailViewModel>();

        CreateMap<CreateAuthorModel, Author>();
    }
}


