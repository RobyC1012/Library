using Library.Utils.Factory;

namespace Library.Models;

public class BookParamFactory : ParamFactory
{
    public String author;
    
    public BookParamFactory(string? title, String author)
    {
        this.Title = title;
        this.author = author;
    }
}