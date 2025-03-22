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
                        Title = "Lean Startuup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 1, 1)
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2002, 1, 1)
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreId = 3,
                        PageCount = 540,
                        PublishDate = new DateTime(2003, 1, 1)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}