using Library.Models;
using Library.Utils;
using Library.Utils.Factory;

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
        member.ID = _memberList.Size()+1;
        _memberList.InsertMember(member);
    }
    
    public void ShowElems()
    {
        _elemList.GetAllBooks();
        _elemList.GetAllMagazines();
    }
    
    public void ShowMembers()
    {
        _memberList.GetAllMembers();
    }
    
}

