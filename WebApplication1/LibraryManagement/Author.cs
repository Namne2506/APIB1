namespace WebApplication1.LibraryManagement
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
