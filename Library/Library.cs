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
        Console.WriteLine($"Member added successfully. [ID: {member.Id}, Name: {member.name}, Phone: {member.phone}, Address: {member.address}]");
    }

    public void BorrowElem(int ID_member, int ID_elem)
    {
        Member member = _memberList.SearchMember(ID_member);
        AbstractElem elem = _elemList.SearchElem(ID_elem);
        
        if (member == null) Console.WriteLine("\nMember not found.\n");
        else if (elem == null) Console.WriteLine("\nElement not found.\n");
        else _memberList.BorrowElem(member, elem);
        
    }
    
    public bool HasBorrowedElem(int memberId2)
    {
        Member member = _memberList.SearchMember(memberId2);
        return member.borrowedElems.Count > 0;
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

    public void VisitElems(ShowVisitor visitor)
    {
        _elemList.Accept(visitor);
    }

    public void VisitBooks(ShowVisitor visitor)
    {
        _elemList.AcceptBooks(visitor);
    }

    public void VisitMagazines(ShowVisitor visitor)
    {
        _elemList.AcceptMagazines(visitor);
    }

    public void VisitMembers(ShowVisitor visitor)
    {
        _memberList.Accept(visitor);
    }


    public void ShowBorrowedElems(int memberId2)
    {
        Member member = _memberList.SearchMember(memberId2);
        foreach (var elem in member.borrowedElems)
        {
            if (elem is Book b)
            {
                Console.WriteLine($"[ID: {b.Id}, Title: {b.title}, Author: {b.author}, Limit Date: {b.returnDate}({(b.returnDate<DateTime.Now?"Late":"Ok")})]");
            }
            else if (elem is Magazine m)
            {
                Console.WriteLine($"[ID: {m.Id}, Title: {m.title}, Number: {m.number}, Limit Date: {m.returnDate}({(m.returnDate<DateTime.Now?"Late":"Ok")})]");
            }
        }
    }
}

