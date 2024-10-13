using Microsoft.EntityFrameworkCore;

namespace WebApplication1.LibraryManagement
{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext()
        {
        }

        public AuthorDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BookBorrowing> BookBorrowings  { get; set; }
    }
}
