using Library.Models;

namespace Library.Utils;
public class ElemList : GenList<AbstractElem, int>
{
    private static ElemList _instance = null;
    private ElemList() {}
    public static ElemList Instance() => _instance == null ? _instance = new ElemList() : _instance;

    
    public bool InsertElem(AbstractElem elem)
    {
        AddElem(elem.Id, elem);
        return true;
    }

    public AbstractElem SearchBook(int ID_book)
    {
        return Get(ID_book);
    }

    public bool Delete(Book book)
    {
        return RemoveElem(book);
    }

    public void GetAllBooks()
    {
        List<AbstractElem> books = GetAll();
        foreach (var book in books)
        {
            if (book is Book b)
            {
                Console.WriteLine("ID: " + b.Id + "; Title: " + b.title + "; Author: " + b.author);
            }
        }
        
    }

    public void GetAllMagazines()
    {
        List<AbstractElem> magazines = GetAll();
        foreach (var magazine in magazines)
        {
            if (magazine is Magazine m)
            {
                Console.WriteLine("ID: " + m.Id + "; Title: " + m.title + "; Number: " + m.number);
            }
        }
    }
}