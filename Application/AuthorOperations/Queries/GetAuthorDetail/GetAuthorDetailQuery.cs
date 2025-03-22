using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;

public class GetAuthorDetailQuery
{
    public int AuthorId { get; set; }
    public readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    
    public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public AuthorDetailViewModel Handle()
    {
        var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
        if (author is null)
            throw new InvalidOperationException("Yazar bulunamadı");
        
        return _mapper.Map<AuthorDetailViewModel>(author);

    }

    public class AuthorDetailViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
    }
}

