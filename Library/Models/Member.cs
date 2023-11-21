namespace Library.Models;

public class Member
{
    public int ID { get; set; }
    public String name { get; set; }
    public String phone { get; set; }
    public String address { get; set; }
    
    public List<AbstractElem> borrowedElems { get; set; }

    public Member(string name, string phone, string address)
    {
        this.name = name;
        this.phone = phone;
        this.address = address;
        borrowedElems = new List<AbstractElem>();
    }

    public void BorrowElem(AbstractElem elem)
    {
        borrowedElems.Add(elem);
        elem.borrowedBy = this;
    }
}