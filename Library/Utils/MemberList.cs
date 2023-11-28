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

    public void BorrowElem(Member member, AbstractElem elem, bool bInHall)
    {
        elem.returnDate = DateTime.Now.AddDays(30);
        elem.borrowedBy = member;
        elem.InHall = bInHall;
        member.borrowedElems.Add(elem);
        Console.WriteLine($"\nMember {member.name} borrowed {elem.title} successfully {(bInHall == true ? "in Library" : "at Home")}. Return limit date: {elem.returnDate}.\n");
    }
    
    public void ReturnElem(Member member, AbstractElem elem)
    {
        if(elem.returnDate > DateTime.Now)
        {
            member.tax += 5;
            Console.WriteLine($"\nMember {member.name} returned {elem.title} with delay. Tax: {member.tax}.\n");
        }
        member.borrowedElems.Remove(elem);
        Console.WriteLine($"Member {member.name} returned {elem.title} successfully.");
    }
    
    public void Accept(Show visitor)
    {
        List<Member> members = GetAll();
        foreach (var member in members)
        {
            visitor.showMember(member);
        }
    }
}