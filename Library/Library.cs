using Library.Models;
using Library.Utils;
using Library.Utils.Factory;
using Library.Utils.Visitor;

namespace Library;

public class Library
{
    private static Library _instance = null;
    private Library() {}
    public static Library? Instance() => _instance == null ? _instance = new Library() : _instance;

    public static ElemList _elemList = ElemList.Instance();
    public static MemberList _memberList = MemberList.Instance();
    public static RetentionList _retentionList = RetentionList.Instance();

    #region Add Member and Elements

    public void AddElem(ParamFactory paramFactory)
    {    
        AbstractElemFactory _elemFactory = AbstractElemFactory.Instance();
        _elemList.InsertElem(_elemFactory.CreateElem(paramFactory));
    }
    
    public void AddMember(String name, String phone, String address)
    {
        Member member = new Member(name, phone, address);
        member.Id = _memberList.Size()+1;
        
        _memberList.InsertMember(member);
        //Console.WriteLine($"Member added successfully. [ID: {member.Id}, Name: {member.name}, Phone: {member.phone}, Address: {member.address}]");
        new ShowVisitor().show(member, 2);
    }

    #endregion
    
    #region Borrow and Return

    public void BorrowElem(int ID_member, int ID_elem, bool bInHall)
    {
        Member member = SearchMember(ID_member);
        AbstractElem elem = SearchElem(ID_elem);
        
        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        
        else if (elem.borrowedBy != null) Console.WriteLine("\nElement already borrowed.\n");
        
        else _memberList.BorrowElem(member, elem);
        
    }

    public void ReturnElem(int memberId2, int elemId)
    {
        Member member = _memberList.SearchMember(memberId2);
        AbstractElem elem = _elemList.SearchElem(elemId);
        
        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else
        {
            _memberList.ReturnElem(member, elem);
            _elemList.ReturnElem(member, elem);
        }
    }
    
    public bool HasBorrowedElem(int memberId2) { return _memberList.SearchMember(memberId2).borrowedElems.Count > 0; }

    #endregion
    
    #region Retentions

    public void PlaceRetention(int member_ID, int book_ID)
    {
        Member member = SearchMember(member_ID);
        AbstractElem elem = SearchElem(book_ID);
        
        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else if(CheckRetention(member, elem)) Console.WriteLine("\nMember already has this retention.\n");
        else
        {
            Retention retention = new Retention(member, elem) 
            {
                Id = _retentionList.Size() + 1
            };
            _retentionList.InsertRetention(retention);
        }
    }

    public void CancelRetention(int member_ID, int book_ID)
    {
        Member member = SearchMember(member_ID);
        AbstractElem elem = SearchElem(book_ID);
        
        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else if(!CheckRetention(member, elem)) Console.WriteLine("\nMember has no retention of this element.\n");
        else
        {
            Retention retention = _retentionList.SearchRetention(member, elem);
            _retentionList.Delete(retention);
        }
    }
    
    //public bool HasRetention(AbstractElem elem) { return _retentionList.HasRetention(elem); }

    private bool CheckRetention(Member member, AbstractElem elem) { return _retentionList.CheckRetention(member, elem); }

    #endregion

    #region Visitor Pattern
    
        public void VisitElems(ShowVisitor visitor) { _elemList.Accept(visitor); }
        public void VisitMembers(ShowVisitor visitor) { _memberList.Accept(visitor); }
        public void VisitRetention(ShowVisitor visitor) { _retentionList.Accept(visitor); }
        public void VisitAvailableBooks(ShowVisitor visitor) { _elemList.AcceptAvailableBooks(visitor); }
        public void VisitAvailableMagazines(ShowVisitor visitor) { _elemList.AcceptAvailableMagazines(visitor); }
        public void VisitBorrowedElems(ShowVisitor visitor, int member_ID) { _elemList.AcceptBorrowedElems(visitor, member_ID); }

        #endregion

    #region Search
    
        public Member SearchMember(int ID_member) { return _memberList.SearchMember(ID_member); }
        public AbstractElem SearchElem(int ID_elem) { return _elemList.SearchElem(ID_elem); }
        
    #endregion
}

