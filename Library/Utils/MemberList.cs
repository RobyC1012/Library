using Library.Models;

namespace Library.Utils;

public class MemberList : GenList<Member, int>
{
    private static MemberList _instance = null;
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
            Console.WriteLine("ID: " + member.ID + "; Name: " + member.name + "; Phone: " + member.phone + "; Address: " + member.address);
        }
    }
    
}