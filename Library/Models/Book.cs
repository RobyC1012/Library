using Library.Utils.Visitor;

namespace Library.Models;

public class Book : AbstractElem
{
    public string author { get; set; }

    public Book(string title, string author) : base(title)
    {
        this.title = title;
        this.author = author;
    }

    public override void Accept(Show visitor, int type)
    {
        visitor.show(this, type);
    }
}