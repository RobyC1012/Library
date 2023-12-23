using Library.Utils.Visitor;

namespace Library.Models;

public class Member
{
    public int id { get; set; }
    public string name { get; set; }
    public string phone { get; set; }
    public string address { get; set; }
    public float tax { get; set; }
    public List<AbstractElem> borrowedElems { get; set; }

    public Member(string name, string phone, string address)
    {
        this.name = name;
        this.phone = phone;
        this.address = address;
        tax = 0;
        borrowedElems = new List<AbstractElem>();
    }

    public void BorrowElem(AbstractElem elem)
    {
        borrowedElems.Add(elem);
        elem.borrowedBy = this;
    }

    public void ReturnElem(AbstractElem elem)
    {
        borrowedElems.Remove(elem);
        elem.borrowedBy = null;
    }

    public void Accept(Show visitor)
    {
        visitor.show(this);
    }
}