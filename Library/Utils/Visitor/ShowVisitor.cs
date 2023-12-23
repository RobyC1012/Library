using System.Reflection.Metadata.Ecma335;
using Library.Models;
using Library.Models.Decorator;

namespace Library.Utils.Visitor;

public class ShowVisitor : Show
{
    public void show(Book book, int type = 1)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine($"ID: {book.Id}, Title: {book.title}, Author: {book.author}" +
                                  (book.borrowedBy != null
                                      ? $" Borrowed by: {book.borrowedBy.name}[ID: {book.borrowedBy.id}]."
                                      : ". "));
                break;
            case 2:
                Console.WriteLine(
                    $"Book added successfully. [ID: {book.Id}, Title: {book.title}, Author: {book.author}]");
                break;
            case 3:
                Console.WriteLine(
                    $"Book deleted successfully. [ID: {book.Id}, Title: {book.title}, Author: {book.author}]");
                break;
        }
    }

    public void show(Magazine magazine, int type = 1)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine($"ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}" +
                                  (magazine.borrowedBy != null
                                      ? $" Borrowed by: {magazine.borrowedBy.name}[ID: {magazine.borrowedBy.id}]."
                                      : ". "));
                break;
            case 2:
                Console.WriteLine(
                    $"Magazine added successfully. [ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}]");
                break;
            case 3:
                Console.WriteLine($"Magazine deleted successfully. [ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}]");
                break;
        }
    }


    public void show(ElemWithTax elem, int type)
    {
        if (elem.elem is Book b)
        {
            switch (type)
            {
                case 1:
                    Console.WriteLine($"ID: {b.Id}, Title: {b.title}, Author: {b.author}, Tax: {elem.tax}" +
                                      (elem.borrowedBy != null
                                          ? $" Borrowed by: {elem.borrowedBy.name}[ID: {elem.borrowedBy.id}]."
                                          : ". "));
                    break;
                case 2:
                    Console.WriteLine(
                        $"Book added successfully. [ID: {b.Id}, Title: {b.title}, Author: {b.author}, Tax: {elem.tax}]");
                    break;
                case 3:
                    Console.WriteLine(
                        $"Book deleted successfully. [ID: {b.Id}, Title: {b.title}, Author: {b.author}, Tax: {elem.tax}]");
                    break;
            }
        }
        else if (elem.elem is Magazine m)
        {
            switch (type)
            {
                case 1:
                    Console.WriteLine($"ID: {m.Id}, Title: {m.title}, Number: {m.number}, Tax: {elem.tax}" +
                                      (elem.borrowedBy != null
                                          ? $" Borrowed by: {elem.borrowedBy.name}[ID: {elem.borrowedBy.id}]."
                                          : ". "));
                    break;
                case 2:
                    Console.WriteLine(
                        $"Magazine added successfully. [ID: {m.Id}, Title: {m.title}, Number: {m.number}, Tax: {elem.tax}]");
                    break;
                case 3: 
                    Console.WriteLine(
                        $"Magazine deleted successfully. [ID: {m.Id}, Title: {m.title}, Number: {m.number}, Tax: {elem.tax}]");
                    break;
            }
        }
        else if (elem.elem is ElemInRoom eleminroom)
        {
            if (eleminroom.elem is Book book)
                switch (type)
                {
                    case 1:
                        Console.WriteLine(
                            $"ID: {book.Id}, Title: {book.title}, Author: {book.author}, Tax: {elem.tax}, In Room: true" +
                            (elem.borrowedBy != null
                                ? $", Borrowed by: {elem.borrowedBy.name}[ID: {elem.borrowedBy.id}]."
                                : ". "));
                        break;
                    case 2:
                        Console.WriteLine(
                            $"Book added successfully. [ID: {book.Id}, Title: {book.title}, Author: {book.author}, Tax: {elem.tax}, In Room: true]");
                        break;
                    case 3: 
                        Console.WriteLine($"Book deleted successfully. [ID: {book.Id}, Title: {book.title}, Author: {book.author}, Tax: {elem.tax}, In Room: true]");
                        break;
                }
            else if (eleminroom.elem is Magazine magazine)
                switch (type)
                {
                    case 1:
                        Console.WriteLine(
                            $"ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}, Tax: {elem.tax}, In Room: true" +
                            (elem.borrowedBy != null
                                ? $", Borrowed by: {elem.borrowedBy.name}[ID: {elem.borrowedBy.id}]."
                                : ". "));
                        break;
                    case 2:
                        Console.WriteLine(
                            $"Magazine added successfully. [ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}, Tax: {elem.tax}, In Room: true]");
                        break;
                    case 3:
                        Console.WriteLine($"Magazine deleted successfully. [ID: {magazine.Id}, Title: {magazine.title}, Number: {magazine.number}, Tax: {elem.tax}, In Room: true]");
                        break;
                }
        }
    }

    public void show(ElemInRoom elem, int type)
    {
        if (elem.elem is Book b)
            switch (type)
            {
                case 1:
                    Console.WriteLine($"ID: {b.Id}, Title: {b.title}, Author: {b.author}, In room: {elem.inRoom}" +
                                      (elem.borrowedBy != null
                                          ? $", Borrowed by: {elem.borrowedBy.name}[ID: {elem.borrowedBy.id}]."
                                          : ". "));
                    break;
                case 2:
                    Console.WriteLine(
                        $"Book added successfully. [ID: {b.Id}, Title: {b.title}, Author: {b.author}, In room: {elem.inRoom}]");
                    break;
                case 3:
                    Console.WriteLine($"Book deleted successfully. [ID: {b.Id}, Title: {b.title}, Author: {b.author}, In room: {elem.inRoom}]");
                    break;
            }
        else if (elem.elem is Magazine m)
            switch (type)
            {
                case 1:
                    Console.WriteLine($"ID: {m.Id}, Title: {m.title}, Number: {m.number}, In room: {elem.inRoom}" +
                                      (elem.borrowedBy != null
                                          ? $", Borrowed by: {elem.borrowedBy.name}[ID: {elem.borrowedBy.id}]."
                                          : ". "));
                    break;
                case 2:
                    Console.WriteLine(
                        $"Magazine added successfully. [ID: {m.Id}, Title: {m.title}, Number: {m.number}, In room: {elem.inRoom}]");
                    break;
                case 3:
                    Console.WriteLine($"Magazine deleted successfully. [ID: {m.Id}, Title: {m.title}, Number: {m.number}, In room: {elem.inRoom}]");
                    break;
            }
    }

    public void show(List<AbstractElem> elemList, int type = 1)
    {
        foreach (var elem in elemList) show(elem, type);
    }

    public void show(AbstractElem elem, int type)
    {
        if (elem is Book b) show(b, type);
        else if (elem is Magazine m) show(m, type);
        else if (elem is ElemWithTax et) show(et, type);
        else if (elem is ElemInRoom er) show(er, type);
    }

    public void show(Member member, int type)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine(
                    $"ID: {member.id}, Name: {member.name}, Address: {member.address}, Phone: {member.phone}, Tax: {member.tax}.");
                foreach (var elem in member.borrowedElems)
                    if (elem is Book b)
                        Console.WriteLine(
                            $" > Book - ID: {elem.Id}; Title: {elem.title}; Author: {b.author}; Return date: {elem.returnDate}.");
                    else if (elem is Magazine m)
                        Console.WriteLine(
                            $" > Magazine - ID: {elem.Id}; Title: {elem.title}; Number: {m.number}; Return date: {elem.returnDate}");
                break;
            case 2:
                Console.WriteLine(
                    $"Member added successfully. [ID: {member.id}, Name: {member.name}, Address: {member.address}, Phone: {member.phone}]");
                break;
            case 3:
                Console.WriteLine(
                    $"Member deleted successfully. [ID: {member.id}, Name: {member.name}, Address: {member.address}, Phone: {member.phone}]");
                break;
        }
    }

    public void show(Member member, AbstractElem elem, int type = 1)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine(
                    $"Member {member.name} borrowed {elem.title} successfully. Return limit date: {elem.returnDate}.");
                break;
            case 2:
                Console.WriteLine(
                    $"Member {member.name} returned {elem.title} successfully{(elem.returnDate < DateTime.Now ? $" with deelay. Tax: {member.tax}" : "")}.");
                break;
        }
    }

    public void show(Retention retention, int type = 1)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine(
                    $"ID: {retention.id}, Member: {retention.member.name}, Element: {retention.elem.title}");
                break;
            case 2:
                Console.WriteLine(
                    $"Retention added successfully. [ID: {retention.id}, Member: {retention.member.name}, Element: {retention.elem.title}]");
                break;
            case 3:
                Console.WriteLine(
                    $"Retention cancelled successfully. [ID: {retention.id}, Member: {retention.member.name}, Element: {retention.elem.title}]");
                break;
        }
    }

    public void show(List<Retention> retentionList)
    {
        foreach (var retention in retentionList) show(retention);
    }

    public void show(Transactions transactions, int type)
    {
        switch (type)
        {
            case 1:
                Console.WriteLine(
                    $"ID: {transactions.id}, Member: {transactions.id_member}, Element: {transactions.id_elem}, Text:{transactions.text}, Date: {transactions.date} " + (transactions.date_return != null ? $", Return date: {transactions.date_return}" : ""));
                break;
        }
    }
}