public class Author
{

    public Author()
    {
        List<Book> Books = new List<Book>();
    }

    public int AuthorId { get; set; }
    public string AuthorName { get; set; } = string.Empty;

    public IList<Book> Books { get; set; }
}