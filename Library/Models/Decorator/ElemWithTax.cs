using Library.Utils.Visitor;

namespace Library.Models.Decorator;

public class ElemWithTax : AbstractElem
{
    public float tax { get; set; }
    public AbstractElem elem { get; set; }
    
    public ElemWithTax(AbstractElem elem, float tax)
    {
        this.elem = elem;
        this.tax = tax;
    }
    
    public override void Accept(Show visitor, int type)
    {
        throw new NotImplementedException();
    }
    
}