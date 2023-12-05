using System.Collections;
using Library.Models;
using Library.Models.Decorator;
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
        new ShowVisitor().show(elem, 2);
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
        List<AbstractElem> elem = GetAll();
        visitor.show(elem);
    }

    public void ReturnElem(Member member, AbstractElem elem)
    {
        elem.borrowedBy = null;
    }

    public void AcceptBorrowedElems(ShowVisitor visitor , int member_ID)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
        {
            if (elem is Book b && b.borrowedBy != null && b.borrowedBy.Id == member_ID)
            {
                visitor.show(b);
            }
            else if (elem is Magazine m && m.borrowedBy != null && m.borrowedBy.Id == member_ID)
            {
                visitor.show(m);
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
                visitor.show(m);
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
                visitor.show(b);
            }
        }
    }
}