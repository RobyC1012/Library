using Library.Utils.Visitor;

namespace Library.Models;

public class Retention
{
    public int Id { get; set; }
    public Member member { get; set; }
    public AbstractElem elem { get; set; }
    public DateTime date { get; set; }

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