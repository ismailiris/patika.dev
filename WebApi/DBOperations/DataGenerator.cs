using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Frank",
                        Surname = "Herbert",
                        Birthday = new DateTime(1920,10,8)
                    },
                    new Author
                    {
                        Name = "Charlotte",
                        Surname = "Perkins Gilman",
                        Birthday = new DateTime(1860,7,3)
                    },
                    new Author
                    {
                        Name = "Eric",
                        Surname = "Ries",
                        Birthday = new DateTime(1978,9,22)
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth",
                    },
                    new Genre
                    {
                        Name = "Sicence Fiction",
                    },
                    new Genre
                    {
                        Name = "Romance",
                    }
                );

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Lean Startup",
                        GenreID = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12),
                        AuthorID = 2
                    },
                    new Book
                    {
                        Title = "Herland",
                        GenreID = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23),
                        AuthorID = 3
                    },
                    new Book
                    {
                        Title = "Dune",
                        GenreID = 2,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 12, 21),
                        AuthorID = 1
                    }
                );

                context.SaveChanges();
            }
        }
    }
}