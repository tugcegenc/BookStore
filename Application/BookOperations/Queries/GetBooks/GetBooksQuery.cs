using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.BookOperations.Queries
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public GetBooksQuery(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<BookViewModel> Handle()
        {
            var bookList = _dbcontext.Books.Include(x => x.Genre).OrderBy(x => x.Id).ToList<Book>();
            List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(bookList);
                
                
         /*       
                new List<BookViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BookViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                    PageCount = book.PageCount
                });
               }  
                */
           
            return vm;
        }
    }
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}