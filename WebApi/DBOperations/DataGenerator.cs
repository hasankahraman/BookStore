using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WebApi.DBOperations;


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
                context.Books.AddRange(
                    new Book{
                        Title = "Lean Startup",
                        GenreId = 1, //Personel Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2003,02,02)
                    },
                    new Book{
                        Title = "Herland",
                        GenreId = 2, //Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,14)
                    },
                    new Book{
                        Title = "Dune",
                        GenreId = 2, //Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2016,09,27)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}