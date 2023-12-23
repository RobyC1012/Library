using Library.Utils.Visitor;

namespace Library.Models;

public class Magazine : AbstractElem
{
    public int number;

    public Magazine(string title, int number) : base(title)
    {
        this.title = title;
        this.number = number;
    }

    public override void Accept(Show visitor, int type)
    {
        visitor.show(this, type);
    }
}