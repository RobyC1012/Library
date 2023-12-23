using Library.Models;
using Library.Models.Decorator;
using Library.Utils.Visitor;

namespace Library.Utils;

public class MemberList : GenList<Member, int>
{
    private static MemberList _instance;
    private MemberList(){ }
    public static MemberList Instance() => _instance == null ? _instance = new MemberList() : _instance;

    public bool InsertMember(Member member)
    {
        AddElem(member.id, member);
        new ShowVisitor().show(member, 2);
        Library.InsertTransaction(member.id,0,$"Member {member.name} has been added.", DateTime.Now);
        return true;
    }

    public Member? SearchMember(int ID_member)
    {
        return Get(ID_member);
    }

    public bool Delete(Member member)
    {
        if (member == null)
        {
            Console.WriteLine("\nMember not found.\n");
            return false;
        }
        if (member.borrowedElems.Count > 0)
        {
            Console.WriteLine("\nMember cannot be deleted because has borrowed elements.\n");
            return false;
        }
        new ShowVisitor().show(member, 3);
        Library.InsertTransaction(member.id,0,$"Member {member.name} has been deleted.", DateTime.Now);
        return RemoveElem(member);
    }

    public void BorrowElem(Member member, AbstractElem elem)
    {
        if(elem is ElemWithTax e && e.tax > 0) member.tax += e.tax;
        elem.returnDate = DateTime.Now.AddDays(30);
        elem.borrowedBy = member;
        member.borrowedElems.Add(elem);
        new ShowVisitor().show(member, elem, 1);
        Library.InsertTransaction(member.id, elem.Id,$"Member {member.name} has borrowed element {elem.title}[ID: {elem.Id}].", DateTime.Now, elem.returnDate);
    }

    public void ReturnElem(Member member, AbstractElem elem)
    {
        if (elem.returnDate < DateTime.Now) member.tax += 5;
        member.borrowedElems.Remove(elem);
        new ShowVisitor().show(member, elem, 2);
        Library.InsertTransaction(member.id, elem.Id,$"Member {member.name} has returned element {elem.title}[ID: {elem.Id}].", DateTime.Now);
    }

    public void Accept(Show visitor)
    {
        List<Member> members = GetAll();
        foreach (var member in members) visitor.show(member);
    }
}