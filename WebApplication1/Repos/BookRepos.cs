using Microsoft.EntityFrameworkCore;
using WebApplication1.LibraryManagement;

namespace WebApplication1.Repos
{
    public class BookRepos
    {
        private readonly AuthorDbContext _context;
        private readonly DbSet<Book> books;

        public BookRepos(AuthorDbContext context, DbSet<Book> books)
        {
            _context = context;
            this.books = books;
        }
        public bool Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Book> GetAll()
        {
            return books.ToList();
        }
        public Book GetBookById(int BookId)
        {
            try
            {
                return books.FirstOrDefault(b => b.BookId == BookId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public bool Update(Book book)
        {
            try
            {
                var bookFind = books.FirstOrDefault(x => x.BookId == book.BookId);
                if (bookFind != null)
                {
                    bookFind.BookId = book.BookId;
                    bookFind.Title = book.Title;
                    bookFind.AuthorId = book.AuthorId;
                    bookFind.PulishYear = book.PulishYear;

                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(Book book)
        {
            try
            {

                _context.Remove(book);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
