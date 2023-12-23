using Library.Utils.Visitor;

namespace Library.Models.Decorator;

public class ElemInRoom : AbstractElem
{
    public bool inRoom { get; set; }
    public AbstractElem elem { get; set; }

    public ElemInRoom(AbstractElem Elem, bool InRoom) : base(Elem.title)
    {
        elem = Elem;
        title = Elem.title;
        Id = Elem.Id;
        inRoom = InRoom;
    }

    public override void Accept(Show visitor, int type)
    {
        visitor.show(this, type);
    }
}