using Library.Models;
using Library.Utils.Factory;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        Library? library = Library.Instance();
        
        Menu();
        int option = int.Parse(Console.ReadLine()!);
        while (option != 10)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Magazine");
                    int option2 = int.Parse(Console.ReadLine()!);
                    switch (option2)
                    {
                        case 1:
                            Console.WriteLine("Title: ");
                            string? bTitle = Console.ReadLine();
                            Console.WriteLine("Author: ");
                            String author = Console.ReadLine();
                            library?.AddElem(new BookParamFactory(bTitle, author));
                            break;
                        case 2:
                            Console.WriteLine("Title: ");
                            string? mTitle = Console.ReadLine();
                            Console.WriteLine("Number: ");
                            int number = int.Parse(Console.ReadLine()!);
                            library?.AddElem(new MagazineParamFactory(mTitle, number));
                            break;
                    }

                    break;
                
                case 2:
                    Console.WriteLine("Name:");
                    string? name = Console.ReadLine();
                    Console.WriteLine("Phone:");
                    string? phone = Console.ReadLine();
                    Console.WriteLine("Address:");
                    string? address = Console.ReadLine();
                    
                    library?.AddMember(name,phone,address);

                    break;
                
                case 3:
                    Console.WriteLine("Choose item to borrow:\n 1. Book\n 2. Magazine");
                    int option3 = int.Parse(Console.ReadLine()!);
                    
                    Console.WriteLine("Enter member ID:");
                    int memberID = int.Parse(Console.ReadLine()!);
                    
                    library.ShowElems();
                    
                    Console.WriteLine("Enter item ID:");
                    int itemID = int.Parse(Console.ReadLine()!);
                    
                    library.BorrowElem(memberID, itemID);
                    
                    
                    break;
                case 4:
                    Console.WriteLine("NOT IMPLEMENTED");
                    break;
                case 5:
                    library?.ShowMembers();
                    break;
                case 6:
                    library?.ShowElems();
                    break;
                case 10:
                    break;
            }
            Menu();
            option = int.Parse(Console.ReadLine()!);
        }
    }

    public static void Menu()
    {
        Console.WriteLine("1. Add element");
        Console.WriteLine("2. Add member");
        Console.WriteLine("3. Borrow");
        Console.WriteLine("4. Show magazines - NOT IMPLEMENTED");
        Console.WriteLine("5. Show members");
        Console.WriteLine("6. Show Elements");
        Console.WriteLine("10. Exit");
    }
}
