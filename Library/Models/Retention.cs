using Library.Utils.Visitor;

namespace Library.Models;

public class Retention
{
    public int id { get; set; }
    public Member member { get; }
    public AbstractElem elem { get; }
    public DateTime date { get; }

    public Retention(Member member, AbstractElem elem)
    {
        this.member = member;
        this.elem = elem;
        date = DateTime.Now;
    }

    public void Accept(Show visitor)
    {
        visitor.show(this);
    }
}