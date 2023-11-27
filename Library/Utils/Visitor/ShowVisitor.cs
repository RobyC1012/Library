using Library.Models;

namespace Library.Utils.Visitor;

public class ShowVisitor : Show
{
    public void showBook(Book book)
    {
        Console.WriteLine($"ID: {book.Id}, Title: {book.title}, Author: {book.author}" + (book.borrowedBy != null ? $" Borrowed by: {book.borrowedBy.name}[ID: {book.borrowedBy.Id}]." : ". " ));
    }

    public void showMagazine(Magazine magazine)
    {
        Console.WriteLine($"ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}" + (magazine.borrowedBy != null ? $" Borrowed by: {magazine.borrowedBy.name}[ID: {magazine.borrowedBy.Id}]." : ". "));
    }

    public void showMember(Member member)
    {
        Console.WriteLine($"ID: {member.Id}, Name: {member.name}, Surname: {member.phone}, Address: {member.address}, Tax: {member.tax}" + (member.borrowedElems.Count > 0 ? " Borrowed elements: " : ". "));
        foreach (var elem in member.borrowedElems)
        {
            if (elem is Book b)
            {
                Console.WriteLine($" > Book - ID: {elem.Id}; Title: {elem.title}; Author: {b.author}; Return date: {elem.returnDate}.");
            } else if (elem is Magazine m)
            {
                Console.WriteLine($" > Magazine - ID: {elem.Id}; Title: {elem.title}; Number: {m.number}; Return date: {elem.returnDate}.");
            }
        }
    }
    
    public void showRetention(Retention retention)
    {
        Console.WriteLine($"ID: {retention.Id}, Member: {retention.member.name}[ID: {retention.member.Id}], Element: {retention.elem.title}[ID: {retention.elem.Id}], Date: {retention.date}, Tax: {retention.member.tax}");
    }
}