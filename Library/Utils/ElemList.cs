using Library.Models;

namespace Library.Utils;
public class ElemList : GenList<AbstractElem, int> 
{
    private static ElemList _instance;
    private ElemList() {}
    public static ElemList Instance() => _instance == null ? _instance = new ElemList() : _instance;

    
    public bool InsertElem(AbstractElem elem)
    {
        AddElem(elem.Id, elem);
        if (elem is Book b)
        {
            Console.WriteLine($"\nBook added successfully. [ID: {b.Id}, Title: {b.title}, Author: {b.author}]\n");
        } else if(elem is Magazine m){
            Console.WriteLine($"\nMagazine added successfully. [ID: {m.Id}, Title: {m.title}, Number: {m.number}]\n");
        }
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
        List<AbstractElem> elems = GetAll();
        foreach (var book in elems)
        {
            if (book is Book b)
            {
                Console.WriteLine("ID: " + b.Id + "; Title: " + b.title + "; Author: " + b.author);
            }
        }
        
    }

    public void GetAllMagazines()
    {
        List<AbstractElem> elems = GetAll();
        foreach (var magazine in elems)
        {
            if (magazine is Magazine m)
            {
                Console.WriteLine("ID: " + m.Id + "; Title: " + m.title + "; Number: " + m.number);
            }
        }
    }
}