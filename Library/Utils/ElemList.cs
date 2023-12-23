using System.Collections;
using Library.Models;
using Library.Models.Decorator;
using Library.Utils.Visitor;

namespace Library.Utils;

public class ElemList : GenList<AbstractElem, int>
{
    private static ElemList _instance;
    private ElemList() { }
    public static ElemList Instance() => _instance == null ? _instance = new ElemList() : _instance;

    #region Operations
    public bool InsertElem(AbstractElem elem)
    {
        AddElem(elem.Id, elem);
        new ShowVisitor().show(elem, 2);
        Library.InsertTransaction(0, elem.Id,$"Element {elem.title} has been added.", DateTime.Now, null);
        return true;
    }
    
    public bool Delete(AbstractElem elem)
    {
        if(isBorrowed(elem))
        {
            Console.WriteLine("\nElement cannot be deleted because is borrowed by someone.\n");
            return false;
        }
        if(hasRetention(elem))
        {
            Console.WriteLine("\nElement cannot be deleted because has retention.\n");
            return false;
        }
        new ShowVisitor().show(elem, 3);
        Library.InsertTransaction(0, elem.Id,$"Element {elem.title} has been deleted.", DateTime.Now, null);
        return RemoveElem(elem);
    }

    public AbstractElem SearchElem(int idBook)
    {
        return Get(idBook);
    }

    public void ReturnElem(Member member, AbstractElem elem)
    {
        elem.borrowedBy = null;
        //Notify member witch has retention for this element
        Retention retention = Library._retentionList.GetFirstRetentionByDate(elem);
        if (retention != null)
        {
            Console.WriteLine(
                $"A notification has been sent to {retention.member.name} for element {retention.elem.title}[ID: {retention.elem.Id}].");
            Library._retentionList.Delete(retention);
        }
    }
    
    private bool isBorrowed(AbstractElem elem)
    {
        return elem.borrowedBy != null;
    }

    private bool hasRetention(AbstractElem elem)
    {
        return Library._retentionList.HasRetention(elem);
    }

    #endregion
    
    #region Visitor Functions

    public void Accept(ShowVisitor visitor)
    {
        List<AbstractElem> elem = GetAll();
        visitor.show(elem);
    }

    public void AcceptBorrowedElems(ShowVisitor visitor, int member_ID)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
            if (elem is Book b && b.borrowedBy != null && b.borrowedBy.id == member_ID)
                visitor.show(b);
            else if (elem is Magazine m && m.borrowedBy != null && m.borrowedBy.id == member_ID) visitor.show(m);
    }

    public void AcceptAvailableMagazines(ShowVisitor visitor)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
            if (isMagazine(elem) && elem.borrowedBy == null)
                visitor.show(elem, 1);
    }

    public void AcceptAvailableBooks(ShowVisitor visitor)
    {
        List<AbstractElem> elems = GetAll();
        foreach (var elem in elems)
            if (isBook(elem) && elem.borrowedBy == null)
                visitor.show(elem, 1);
    }

    #endregion

    #region Decorator Check Functions

    public bool isBook(AbstractElem elem)
    {
        if (elem is Book) return true;
        if (elem is ElemWithTax et)
        {
            if (et.elem is Book b) return true;
            if (et.elem is ElemInRoom er)
                if (er.elem is Book b2)
                    return true;
        }

        if (elem is ElemInRoom er2)
            if (er2.elem is Book)
                return true;

        return false;
    }

    public bool isMagazine(AbstractElem elem)
    {
        if (elem is Magazine) return true;
        if (elem is ElemWithTax et)
        {
            if (et.elem is Magazine m) return true;
            if (et.elem is ElemInRoom er)
                if (er.elem is Magazine m2)
                    return true;
        }

        if (elem is ElemInRoom er2)
            if (er2.elem is Magazine)
                return true;

        return false;
    }

    public bool isElemInRoom(AbstractElem elem)
    {
        if (elem is ElemInRoom er) return true;
        if (elem is ElemWithTax et)
            if (et.elem is ElemInRoom er2)
                return true;
        return false;
    }

    public bool isElemWithTax(AbstractElem elem)
    {
        if (elem is ElemWithTax et) return true;
        return false;
    }

    #endregion
}