namespace Library.Models;
public class Book : AbstractElem
{
    public string author { get; set; }

    public Book(string? title, String author) : base(title)
    {
        this.title = title;
        this.author = author;
    }
}