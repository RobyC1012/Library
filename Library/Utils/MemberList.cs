using Library.Models;
using Library.Utils.Visitor;

namespace Library.Utils;

public class MemberList : GenList<Member, int> 
{
    private static MemberList _instance;
    private MemberList() {}
    public static MemberList Instance() => _instance == null ? _instance = new MemberList() : _instance;
    
    public bool InsertMember(Member member)
    {
        AddElem(member.Id, member);
        new ShowVisitor().show(member, 2);
        return true;
    }

    public Member SearchMember(int ID_member)
    {
           return Get(ID_member);
    }
    
    public bool Delete(Member member)
    {
        return RemoveElem(member);
    }

    public void BorrowElem(Member member, AbstractElem elem)
    {
        elem.returnDate = DateTime.Now.AddDays(30);
        elem.borrowedBy = member;
        member.borrowedElems.Add(elem);
        new ShowVisitor().show(member, elem, 1);
    }
    
    public void ReturnElem(Member member, AbstractElem elem)
    {
        if(elem.returnDate < DateTime.Now)
        {
            member.tax += 5;
        }
        member.borrowedElems.Remove(elem);
        new ShowVisitor().show(member, elem, 2);
    }
    
    public void Accept(Show visitor)
    {
        List<Member> members = GetAll();
        foreach (var member in members)
        {
            visitor.show(member);
        }
    }
}