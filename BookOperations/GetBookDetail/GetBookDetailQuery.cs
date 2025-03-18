using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbcontext.Books.Where(x => x.Id == BookId).SingleOrDefault();

            if (book is null)
                throw new InvalidOperationException("Kitap bulunamadı.");

            
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.PageCount = book.PageCount;
            return vm;
        }
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PublishDate { get; set; }
        public int PageCount { get; set; }
    }
}