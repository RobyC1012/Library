using Library.Utils.Visitor;

namespace Library.Models;

public abstract class AbstractElem
{
    public int Id { get; set; }
    public string title { get; set; }
    public DateTime? returnDate { get; set; }
    public Member? borrowedBy { get; set; }

    protected AbstractElem(string? title)
    {
        this.title = title;
        borrowedBy = null;
        returnDate = null;
    }

    public abstract void Accept(Show visitor, int type);
}