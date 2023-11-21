using Library.Models;

namespace Library.Utils;

public class MemberList : GenList<Member, int>
{
    private static MemberList _instance;
    private MemberList() {}
    public static MemberList Instance() => _instance == null ? _instance = new MemberList() : _instance;
    
    public bool InsertMember(Member member)
    {
        AddElem(member.ID, member);
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
    
    public void GetAllMembers()
    {
        List<Member> members = GetAll();
        foreach (var member in members)
        {
            Console.WriteLine("\nID: " + member.ID + "; Name: " + member.name + "; Phone: " + member.phone + "; Address: " + member.address + "; Borrowed elements: ");
            foreach (var elem in member.borrowedElems)
            {
                if (elem is Book b)
                {
                    Console.WriteLine($"Book - ID: {elem.Id}; Title: {elem.title}; Author: {b.author}.");
                } else if (elem is Magazine m)
                {
                    Console.WriteLine($"Magazine - ID: {elem.Id}; Title: {elem.title}; Number: {m.number}.");
                }
            }
        }
    }

    public void BorrowElem(Member member, AbstractElem elem)
    {
        member.borrowedElems.Add(elem);
        Console.WriteLine($"\nMember {member.name} borrowed {elem.title} successfully.\n");
    }
}