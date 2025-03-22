using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;


namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;  
                }
                
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personel Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        AuthorId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 1, 1)
                    },
                    new Book
                    {
                        Title = "Herland",
                        AuthorId = 2,
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2002, 1, 1)
                    },
                    new Book
                    {
                        Title = "Dune",
                        AuthorId = 2,
                        GenreId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2003, 1, 1)
                    }
                );
                context.SaveChanges();
                
                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Leo",
                        LastName = "Tolstoy",
                        DateOfBirth = new DateTime(1828, 9, 9)
                    },
                    new Author
                    {
                        FirstName = "Jane",
                        LastName = "Austen",
                        DateOfBirth = new DateTime(1775, 12, 16)
                    },
                    new Author
                    {
                        FirstName = "George",
                        LastName = "Orwell",
                        DateOfBirth = new DateTime(1903, 6, 25)
                    }

                );
                context.SaveChanges();
            }
        }
    }
}