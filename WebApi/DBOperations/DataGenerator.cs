using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;



namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(
                    new Genre {
                        Name = "Personal Growth",
                    },
                    new Genre {
                        Name = "Science Fiction",
                    },
                    new Genre {
                        Name = "Romance",
                    }
                );

                context.Books.AddRange(
                    new Book{
                        Title = "Lean Startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2003,02,02)
                    },
                    new Book{
                        Title = "Herland",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,14)
                    },
                    new Book{
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2016,09,27)
                    }
                );

                context.Authors.AddRange(
                    new Author{
                        Name = "Dan",
                        Surname = "Brown",
                        Birthday = new DateTime(1980,02,02)
                    },
                    
                    new Author{
                        Name = "Jean Christophe",
                        Surname = "Grange",
                        Birthday = new DateTime(1975,05,05)
                    },
                    
                    new Author{
                        Name = "Ahmet",
                        Surname = "??mit",
                        Birthday = new DateTime(1970,10,03)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}