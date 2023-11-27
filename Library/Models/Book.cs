using Library.Utils.Visitor;

namespace Library.Models;
public class Book : AbstractElem
{
    public String author { get; set; }

    public Book(string? title, String author) : base(title)
    {
        this.title = title;
        this.author = author;
    }
    
    public override void Accept(Show visitor)
    {
        visitor.showBook(this);
    }
}