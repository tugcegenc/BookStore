using WebApi.DBOperations;

namespace WebApi.BookOperations.CeateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbcontext;
        public CreateBookCommand(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
                throw new InvalidOperationException("Kitap zaten mevcut.");
                book = new Book();
                book.Title = Model.Title;
                book.GenreId = Model.GenreId;
                book.PageCount = Model.PageCount;
                book.PublishDate = Model.PublishDate;
          
        }
    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
  
}