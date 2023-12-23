using Library.Utils.Visitor;

namespace Library.Models;

public class Transactions
{
    public int id { get; set; }
    public int? id_member { get; set; }
    public int? id_elem { get; set; }
    public String text { get; set; }
    public DateTime date { get; set; }
    public DateTime? date_return { get; set; }
    
    public Transactions(int idMember, int idElem, string text, DateTime date, DateTime? dateReturn)
    {
        id_member = idMember;
        id_elem = idElem;
        this.text = text;
        this.date = date;
        date_return = dateReturn;
    }
    
    public void Accept(Show visitor, int type)
    {
        visitor.show(this, type);
    }
    
    
}