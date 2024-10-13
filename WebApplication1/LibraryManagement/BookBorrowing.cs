namespace WebApplication1.LibraryManagement
{
    public class BookBorrowing
    {
        public int Id { get; set; }

        public int BorrowerId { get; set; }

        public int BookId { get; set; }

        public DateTime BorrowerDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public virtual Book Book { get; set; }

        public virtual Borrower Borrower { get; set; }
    }
}
