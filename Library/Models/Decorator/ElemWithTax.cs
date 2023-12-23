using Library.Utils.Visitor;

namespace Library.Models.Decorator;

public class ElemWithTax : AbstractElem
{
    public float tax { get; set; }
    public AbstractElem elem { get; set; }

    public ElemWithTax(AbstractElem Elem, float tax) : base(Elem.title)
    {
        elem = Elem;
        title = Elem.title;
        Id = elem.Id;
        this.tax = tax;
    }

    public override void Accept(Show visitor, int type)
    {
        visitor.show(this, type);
    }
}