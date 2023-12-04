using Library.Utils.Visitor;

namespace Library.Models;
public class Book : AbstractElem
{
    public String author { get; set; }

    public Book(string? title, String author) : base(title)
    {
        this.title = title;
        this.author = author;
    }
    
    public override void Accept(Show visitor, int type)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine($"ID: {Id}, Title: {title}, Author: {author}" + (borrowedBy != null ? $" Borrowed by: {borrowedBy.name}[ID: {borrowedBy.Id}]." : ". "));
                break;
            case 2: 
                Console.WriteLine($"Book added successfully. [ID: {Id}, Title: {title}, Author: {author}]");
                break;
        }
    }
}