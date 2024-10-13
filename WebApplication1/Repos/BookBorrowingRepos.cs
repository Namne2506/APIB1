using Microsoft.EntityFrameworkCore;
using WebApplication1.LibraryManagement;

namespace WebApplication1.Repos
{
    public class BookBorrowingRepos
    {
        private readonly AuthorDbContext context;
        private readonly DbSet<BookBorrowing> bookBorrowings;

        public BookBorrowingRepos(AuthorDbContext context, DbSet<BookBorrowing> bookBorrowings)
        {
            this.context = context;
            this.bookBorrowings = bookBorrowings;
        }
        public bool Create(BookBorrowing bookBorrowing)
        {
            try
            {
                context.BookBorrowings.Add(bookBorrowing);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<BookBorrowing> GetAll()
        {
            return context.BookBorrowings.ToList();
        }
        public bool GetBookBorrowingById(int Id)
        {
            try
            {
                var bBorrowing = bookBorrowings.FirstOrDefault(b => b.Id == Id);
                context.SaveChanges();
                return true;
               
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Update(BookBorrowing bookBorrowing)
        {
            try
            {
                var bookBorrowingFind = bookBorrowings.FirstOrDefault(x => x.Id == bookBorrowing.Id);
                if (bookBorrowingFind != null)
                {
                    bookBorrowingFind.Id = bookBorrowing.Id;
                    bookBorrowingFind.BorrowerId = bookBorrowing.BorrowerId;
                    bookBorrowingFind.BookId = bookBorrowing.BookId;

                }
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var bBorrowing = bookBorrowings.FirstOrDefault(b => b.Id == id);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
