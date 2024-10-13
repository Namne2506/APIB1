namespace WebApplication1.LibraryManagement
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int PulishYear { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<BookBorrowing> BookBorrowings { get; set; }
    }
}
