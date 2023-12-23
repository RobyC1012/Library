using System.Runtime.CompilerServices;
using Library.Models;
using Library.Utils;
using Library.Utils.Factory;
using Library.Utils.Visitor;

namespace Library;

public class Library
{
    private static Library _instance = null;
    private Library() { }
    public static Library? Instance() => _instance == null ? _instance = new Library() : _instance;

    public static ElemList _elemList = ElemList.Instance();
    public static MemberList _memberList = MemberList.Instance();
    public static RetentionList _retentionList = RetentionList.Instance();
    public static List<Transactions> _transactions = new();

    #region Add Member and Elements

    public void AddElement(ParamFactory paramFactory)
    {
        var _elemFactory = AbstractElemFactory.Instance();
        _elemList.InsertElem(_elemFactory.CreateElem(paramFactory));
    }

    public void AddMember(string name, string phone, string address)
    {
        var member = new Member(name, phone, address) { id = _memberList.Size() + 1 };
        _memberList.InsertMember(member);
    }

    #endregion
    
    #region Delete Member and Elements
    public void DeleteElem(int bookId)
    {
        AbstractElem elem = SearchElem(bookId);
        if (elem == null) Console.WriteLine("\nElement not found.\n");
        else _elemList.Delete(elem);
    }
    
    public void DeleteMember(int memberId)
    {
        Member member = SearchMember(memberId);
        _memberList.Delete(member);
    }
    
    #endregion

    #region Borrow and Return

    public void BorrowElem(int ID_member, int ID_elem, bool bInHall)
    {
        var member = SearchMember(ID_member);
        var elem = SearchElem(ID_elem);

        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else if (elem.borrowedBy != null) Console.WriteLine("\nElement already borrowed.\n");
        else if (_elemList.isElemInRoom(elem) && !bInHall)
            Console.WriteLine("\nElement can be borrowed only in hall.\n");
        else
            _memberList.BorrowElem(member, elem);
    }

    public void ReturnElem(int memberId2, int elemId)
    {
        var member = _memberList.SearchMember(memberId2);
        var elem = _elemList.SearchElem(elemId);

        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else
        {
            _memberList.ReturnElem(member, elem);
            _elemList.ReturnElem(member, elem);
        }
    }

    public bool HasBorrowedElem(int memberId2)
    {
        return _memberList.SearchMember(memberId2).borrowedElems.Count > 0;
    }

    #endregion

    #region Retentions

    public void PlaceRetention(int member_ID, int book_ID)
    {
        var member = SearchMember(member_ID);
        var elem = SearchElem(book_ID);

        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else if (elem.borrowedBy == null) Console.WriteLine("\nElement is not borrowed.\n");
        else if (CheckRetention(member, elem)) Console.WriteLine("\nMember already has this retention.\n");
        else
        {
            var retention = new Retention(member, elem) { id = _retentionList.Size() + 1 };
            _retentionList.InsertRetention(retention);
        }
    }

    public void CancelRetention(int member_ID, int book_ID)
    {
        var member = SearchMember(member_ID);
        var elem = SearchElem(book_ID);

        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else if (!CheckRetention(member, elem)) Console.WriteLine("\nMember has no retention of this element.\n");
        else
        {
            var retention = _retentionList.SearchRetention(member, elem);
            _retentionList.Delete(retention);
        }
    }

    private bool CheckRetention(Member member, AbstractElem elem)
    {
        return _retentionList.CheckRetention(member, elem);
    }

    #endregion

    #region Visitor Pattern

    public void VisitElems(ShowVisitor visitor)
    {
        _elemList.Accept(visitor);
    }

    public void VisitMembers(ShowVisitor visitor)
    {
        _memberList.Accept(visitor);
    }

    public void VisitRetention(ShowVisitor visitor)
    {
        _retentionList.Accept(visitor);
    }

    public void VisitAvailableBooks(ShowVisitor visitor)
    {
        _elemList.AcceptAvailableBooks(visitor);
    }

    public void VisitAvailableMagazines(ShowVisitor visitor)
    {
        _elemList.AcceptAvailableMagazines(visitor);
    }

    public void VisitBorrowedElems(ShowVisitor visitor, int member_ID)
    {
        _elemList.AcceptBorrowedElems(visitor, member_ID);
    }

    #endregion

    #region Search

    public Member SearchMember(int ID_member)
    {
        return _memberList.SearchMember(ID_member);
    }

    public AbstractElem SearchElem(int ID_elem)
    {
        return _elemList.SearchElem(ID_elem);
    }

    #endregion

    #region Transactions

    public static void InsertTransaction(int member_ID, int elem_ID, String message, DateTime date, DateTime? returnDate = null)
    {
        _transactions.Add(new Transactions(member_ID, elem_ID, message, date, returnDate) { id = _transactions.Count + 1 });
    }
    
    public void ShowTransactions()
    {
        foreach (var transaction in _transactions)
        {
            new ShowVisitor().show(transaction, 1);
        }
    }

    #endregion
    
}