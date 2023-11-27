using Library.Models;
using Library.Utils.Factory;

namespace Library;

public class AbstractElemFactory
{
    private static AbstractElemFactory? _instance;
    private AbstractElemFactory() {}
    public static AbstractElemFactory? Instance() => _instance == null ? _instance = new AbstractElemFactory() : _instance;
    
    
    public AbstractElem CreateElem(ParamFactory paramFactory)
    {
        if (paramFactory.GetType() == typeof(BookParamFactory))
        {
            BookParamFactory bookParamFactory = (BookParamFactory) paramFactory;
            Book book = new Book(bookParamFactory.Title, bookParamFactory.author)
            {
                Id = Library._elemList.Size()+1
            };
            return book;
        }
        else if (paramFactory.GetType() == typeof(MagazineParamFactory))
        {
            MagazineParamFactory magazineParamFactory = (MagazineParamFactory) paramFactory;
            Magazine magazine = new Magazine(magazineParamFactory.Title, magazineParamFactory.Number)
            {
                Id = Library._elemList.Size()+1
            
            };
            return magazine;
        }
        else
        {
            throw new Exception("Invalid type");
        }
    }
    
}