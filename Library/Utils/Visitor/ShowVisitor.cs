using Library.Models;

namespace Library.Utils.Visitor;

public class ShowVisitor : Show
{
    public void show(Book book, int type = 1)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine($"ID: {book.Id}, Title: {book.title}, Author: {book.author}" + (book.borrowedBy != null ? $" Borrowed by: {book.borrowedBy.name}[ID: {book.borrowedBy.Id}]." : ". "));
                break;
            case 2: 
                Console.WriteLine($"Book added successfully. [ID: {book.Id}, Title: {book.title}, Author: {book.author}]");
                break;
        }
    }

    public void show(Magazine magazine, int type = 1)
    {
        switch (type)
        {
            case 1: 
                Console.WriteLine($"ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}" + (magazine.borrowedBy != null ? $" Borrowed by: {magazine.borrowedBy.name}[ID: {magazine.borrowedBy.Id}]." : ". "));
                break;
            case 2:
                Console.WriteLine($"Magazine added successfully. [ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}]");
                break;
        }
    }
    
    public void show(List<AbstractElem> elemList, int type = 1)
    {
        foreach (var elem in elemList)
        {
            show(elem, type);
        }
    }

    public void show(AbstractElem elem, int type) { if(elem is Book b) show(b, type);else if (elem is Magazine m) show(m, type); }

    public void show(Member member, int type)
    {
        switch (type)
        {
            case 1:                 
                Console.WriteLine($"ID: {member.Id}, Name: {member.name}, Address: {member.address}, Phone: {member.phone}, Tax: {member.tax}.");
                foreach (var elem in member.borrowedElems)
                {
                    if (elem is Book b)
                    {
                        Console.WriteLine($" > Book - ID: {elem.Id}; Title: {elem.title}; Author: {b.author}; Return date: {elem.returnDate}.");
                    } else if (elem is Magazine m)
                    {
                        Console.WriteLine($" > Magazine - ID: {elem.Id}; Title: {elem.title}; Number: {m.number}; Return date: {elem.returnDate}");
                    }
                }
                break;
            case 2:
                Console.WriteLine($"Member added successfully. [ID: {member.Id}, Name: {member.name}, Address: {member.address}, Phone: {member.phone}]");
                break;
        }
    }
    
    public void show(Member member, AbstractElem elem, int type = 1)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine($"Member {member.name} borrowed {elem.title} successfully. Return limit date: {elem.returnDate}.");
                break;
            case 2:
                Console.WriteLine($"Member {member.name} returned {elem.title} successfully{(elem.returnDate < DateTime.Now ? $" with deelay. Tax: {member.tax}" : "")}.");
                break;
        }
    }
    
    public void show(Retention retention, int type = 1)
    {
        switch (type)
        {
            case 1: 
                Console.WriteLine($"ID: {retention.Id}, Member: {retention.member.name}, Element: {retention.elem.title}");
                break;
            case 2:
                Console.WriteLine($"Retention added successfully. [ID: {retention.Id}, Member: {retention.member.name}, Element: {retention.elem.title}]");
                break;
            case 3:
                Console.WriteLine($"Retention cancelled successfully. [ID: {retention.Id}, Member: {retention.member.name}, Element: {retention.elem.title}]");
                break;
        }
    }
    public void show(List<Retention> retentionList)
    {
        foreach (var retention in retentionList)
        {
            show(retention);
        }
    }
}