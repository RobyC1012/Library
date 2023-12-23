using Library.Models;
using Library.Models.Decorator;
using Library.Utils.Factory;

namespace Library;

public class AbstractElemFactory
{
    private static AbstractElemFactory? _instance;
    private AbstractElemFactory() { }
    public static AbstractElemFactory? Instance() => _instance == null ? _instance = new AbstractElemFactory() : _instance;
    
    
    public AbstractElem CreateElem(ParamFactory paramFactory)
    {
        if (paramFactory.GetType() == typeof(BookParamFactory))
        {
            var bookParamFactory = (BookParamFactory)paramFactory;
            AbstractElem book =
                new Book(bookParamFactory.Title, bookParamFactory.Author) { Id = Library._elemList.Size() + 1 };

            if (bookParamFactory.InRoom == 1) book = new ElemInRoom(book, true);
            if (bookParamFactory.Tax > 0) book = new ElemWithTax(book, bookParamFactory.Tax);

            return book;
        }

        if (paramFactory.GetType() == typeof(MagazineParamFactory))
        {
            var magazineParamFactory = (MagazineParamFactory)paramFactory;
            AbstractElem magazine =
                new Magazine(magazineParamFactory.Title, magazineParamFactory.Number)
                    { Id = Library._elemList.Size() + 1 };

            if (magazineParamFactory.InRoom == 1) magazine = new ElemInRoom(magazine, true);
            if (magazineParamFactory.Tax > 0) magazine = new ElemWithTax(magazine, magazineParamFactory.Tax);
            return magazine;
        }

        throw new Exception("Invalid paramFactory.");
    }
}