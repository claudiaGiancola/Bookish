using Bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish
{
    public class BookishDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=bookish;User Id=bookish;Password=bookish;");
        }

        //entities from domain classes
        public DbSet<Book> Books { get; set; }
        // public DbSet<Author> Authors { get; set; }
    }
}