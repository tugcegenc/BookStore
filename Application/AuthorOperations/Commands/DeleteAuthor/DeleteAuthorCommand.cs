using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor;

public class DeleteAuthorCommand
{
    public int AuthorId {get; set;}
    private readonly BookStoreDbContext  _context;

    public DeleteAuthorCommand(BookStoreDbContext context)
    {
        _context = context;
    }

    public void Handle()
    {
        var author = _context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
        if (author is null)
            throw new InvalidOperationException("Yazar Bulunamadı");
        
        var hasBooks = _context.Books.Any(x => x.AuthorId == AuthorId);
        if (hasBooks)
            throw new InvalidOperationException("Yayında kitabı olan bir yazar silinemez.");

        
        _context.Authors.Remove(author);
        _context.SaveChanges();
    }
}