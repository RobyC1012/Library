namespace Library.Models;

public abstract class AbstractElem 
{
    public int Id { get; set; }
    public string title { get; set; }
    public Member borrowedBy { get; set; }
    
    protected AbstractElem () {}
    
    protected AbstractElem (string? title)
    {
        this.title = title;
    }
}