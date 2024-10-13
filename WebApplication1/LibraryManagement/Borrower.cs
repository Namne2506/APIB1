namespace WebApplication1.LibraryManagement
{
    public class Borrower
    {
        public int BorrowerId { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<BookBorrowing> BookBorrowings { get; set; }
    }
}