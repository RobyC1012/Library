using Library.Models;
using Library.Utils.Visitor;

namespace Library.Utils;

public class RetentionList : GenList<Retention, int>
{
    private static RetentionList _instance;
    private RetentionList() { }
    public static RetentionList Instance() => _instance == null ? _instance = new RetentionList() : _instance;

    public bool InsertRetention(Retention retention)
    {
        AddElem(retention.id, retention);
        new ShowVisitor().show(retention, 2);
        Library.InsertTransaction(retention.member.id, retention.elem.Id,$"Retention for element {retention.elem.title}[ID: {retention.elem.Id}] has been added by {retention.member.name}[ID: {retention.member.id}].", DateTime.Now);
        return true;
    }

    public Retention SearchRetention(Member member, AbstractElem elem)
    {
        List<Retention> retentions = GetAll();
        foreach (var retention in retentions)
            if (retention.member.Equals(member) && retention.elem.Equals(elem))
                return retention;
        return null;
    }

    public Retention GetFirstRetentionByDate(AbstractElem elem)
    {
        List<Retention> retentions = GetAll();
        retentions.Sort((r1, r2) => r1.date.CompareTo(r2.date));
        foreach (var retention in retentions)
            if (retention.elem.Equals(elem))
                return retention;
        return default;
    }

    public bool CheckRetention(Member member, AbstractElem elem)
    {
        List<Retention> retentions = GetAll();
        foreach (var retention in retentions)
            if (retention.member.Equals(member) && retention.elem.Equals(elem))
                return true;
        return false;
    }

    public bool Delete(Retention retention)
    {
        RemoveElem(retention);
        new ShowVisitor().show(retention, 3);
        Library.InsertTransaction(retention.member.id, retention.elem.Id,$"Retention for element {retention.elem.title}[ID: {retention.elem.Id}] has been deleted for member {retention.member.name}[ID: {retention.member.id}].", DateTime.Now);
        return true;
    }

    public bool HasRetention(AbstractElem elem)
    {
        List<Retention> retentions = GetAll();
        foreach (var retention in retentions)
            if (retention.elem.Equals(elem))
                return true;
        return false;
    }
    
    public void Accept(ShowVisitor visitor)
    {
        List<Retention> retentions = GetAll();
        visitor.show(retentions);
    }
}