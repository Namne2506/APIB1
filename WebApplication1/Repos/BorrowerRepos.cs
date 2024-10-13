using Microsoft.EntityFrameworkCore;
using WebApplication1.LibraryManagement;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplication1.Repos
{
    public class BorrowerRepos
    {
        private readonly AuthorDbContext _context;
        private readonly DbSet<Borrower> borrowers;

        public BorrowerRepos(AuthorDbContext context, DbSet<Borrower> borrowers)
        {
            _context = context;
            this.borrowers = borrowers;
        }
        public bool Create(Borrower borrower)
        {
            try
            {
                _context.Borrowers.Add(borrower);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Borrower> GetAll()
        {
            try
            {
                return borrowers.ToList();
            }
            catch (Exception ex)
            {
                return new List<Borrower>();
            }
        }
        public Borrower GetBorrowerById(int BorrowerId)
        {
            try
            {
                return borrowers.FirstOrDefault(b => b.BorrowerId == BorrowerId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Update(Borrower borrower)
        {
            try
            {
                var borrowerFind = borrowers.FirstOrDefault(x => x.BorrowerId == borrower.BorrowerId);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(Borrower borrower)
        {
            try
            {

                _context.Remove(borrower);
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
