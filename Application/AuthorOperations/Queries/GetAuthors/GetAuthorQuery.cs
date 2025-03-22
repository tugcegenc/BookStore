using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors;

public class GetAuthorsQuery
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<AuthorViewModel> Handle()
    {
        var authors = _context.Authors.OrderBy(x => x.Id).ToList();
        var authorViewModelList = _mapper.Map<List<AuthorViewModel>>(authors);
        return authorViewModelList;
    }
}

public class AuthorViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DateOfBirth { get; set; }
}