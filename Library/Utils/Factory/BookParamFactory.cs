using Library.Utils.Factory;

namespace Library.Models;

public class BookParamFactory : ParamFactory
{
    public string Author;

    public BookParamFactory(string title, string author, int inRoom, float withTax) : base(title, inRoom, withTax)
    {
        Title = title;
        Author = author;
    }
}