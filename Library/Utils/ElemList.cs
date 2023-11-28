using System.Collections;
using Library.Models;
using Library.Utils.Visitor;

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
            Console.WriteLine($"Book added successfully. [ID: {b.Id}, Title: {b.title}, Author: {b.author}]");
        } else if(elem is Magazine m){
            Console.WriteLine($"Magazine added successfully. [ID: {m.Id}, Title: {m.title}, Number: {m.number}]");
        }
        return true;
    }

    public AbstractElem SearchElem(int ID_book)
    {
        return Get(ID_book);
    }

    public bool Delete(Book book)
    {
        return RemoveElem(book);
    }

    public void Accept(ShowVisitor visitor)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
        {
            if (elem is Book b)
            {
                visitor.showBook(b);
            }
            else if (elem is Magazine m)
            {
                visitor.showMagazine(m);
            }
        }
    }

    public void AcceptBooks(ShowVisitor visitor)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
        {
            if (elem is Book b)
            {
                visitor.showBook(b);
            }
        }
    }

    public void AcceptAvailableBooks(ShowVisitor visitor)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
        {
            if (elem is Book b && b.borrowedBy == null)
            {
                visitor.showBook(b);
            }
        }
    }
    
    public void AcceptAvailableMagazines(ShowVisitor visitor)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
        {
            if (elem is Magazine m && m.borrowedBy == null)
            {
                visitor.showMagazine(m);
            }
        }
    }


    public void ReturnElem(Member member, AbstractElem elem)
    {
        elem.borrowedBy = null;
        elem.InHall = null;
    }

    public void AcceptBorrowedElems(ShowVisitor visitor , int member_ID)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
        {
            if (elem is Book b && b.borrowedBy != null && b.borrowedBy.Id == member_ID)
            {
                visitor.showBook(b);
            }
            else if (elem is Magazine m && m.borrowedBy != null && m.borrowedBy.Id == member_ID)
            {
                visitor.showMagazine(m);
            }
        }
    }
}