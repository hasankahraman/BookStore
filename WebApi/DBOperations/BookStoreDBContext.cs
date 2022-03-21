using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class BookStoreDBContext : DbContext, IBookStoreDBContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        { }

        public DbSet<Book> Books {get; set;}
        public DbSet<Genre> Genres {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Author> Authors {get;set;}


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

    }
}