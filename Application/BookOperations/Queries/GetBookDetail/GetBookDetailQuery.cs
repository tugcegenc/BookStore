using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Include(x => x.Genre).Where(x => x.Id == BookId).SingleOrDefault();

            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");


            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
            
            return vm;
           
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}