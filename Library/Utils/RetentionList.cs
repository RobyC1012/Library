using Library.Models;
using Library.Utils.Visitor;

namespace Library.Utils;

public class RetentionList : GenList<Retention, int>
{
    
    private static RetentionList _instance;
    private RetentionList() {}
    public static RetentionList Instance() => _instance == null ? _instance = new RetentionList() : _instance;

    public bool InsertRetention(Retention retention)
    {
        AddElem(retention.Id, retention);
        Console.WriteLine($"Retention added successfully. [ID: {retention.Id}, Member: {retention.member.name}, Element: {retention.elem.title}]");
        return true;
    }

    public Retention SearchRetention(Member member, AbstractElem elem)
    {
        List<Retention> retentions = GetAll();
        foreach (var retention in retentions)
        {
            if (retention.member.Equals(member) && retention.elem.Equals(elem))
            {
                return retention;
            }
        }
        return null;
    }
  
    
    public Retention GetFirstRetentionByDate()
    {
        List<Retention> retentions = GetAll();
        retentions.Sort((x, y) => DateTime.Compare(x.date, y.date));
        return retentions[0];
    }
    
    public bool CheckRetention(Member member, AbstractElem elem)
    {
        List<Retention> retentions = GetAll();
        foreach (var retention in retentions)
        {
            if (retention.member.Equals(member) && retention.elem.Equals(elem))
            {
                return true;
            }
        }
        return false;
    }

    public bool Delete(Retention retention)
    {
        Console.WriteLine(
            $"Retention cancelled successfully. [ID: {retention.Id}, Member: {retention.member.name}, Element: {retention.elem.title}]");
        RemoveElem(retention);
        return true;
    }

    public void Accept(ShowVisitor visitor)
    {
        List<Retention> retentions = GetAll();
        foreach (var retention in retentions)
        {
            visitor.showRetention(retention);
        }
    }

    public bool HasRetention(AbstractElem elem)
    {
        List<Retention> retentions = GetAll();
        foreach (var retention in retentions)
        {
            if (retention.elem.Equals(elem))
            {
                return true;
            }
        }
        return false;
    }
}