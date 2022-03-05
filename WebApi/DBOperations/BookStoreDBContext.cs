using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        { }

        public DbSet<Book> Books {get; set;}
    }
}