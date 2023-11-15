namespace Library.Models;

public class Magazine : AbstractElem
{
    public int number;
    public Magazine(string? title, int number) : base(title)
    {
        this.title = title;
        this.number = number;
    }
}