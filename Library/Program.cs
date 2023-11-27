using Library.Models;
using Library.Utils.Factory;
using Library.Utils.Visitor;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        Library library = Library.Instance(); 
        
        Fill(library);
        
        ShowVisitor showVisitor = new ShowVisitor(); Menu();

        int option3 ,option2, option = int.Parse(Console.ReadLine()!);

        while (option != 7)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Magazine");
                    
                    option2 = int.Parse(Console.ReadLine()!);
                    ParamFactory param = null;
                    
                    switch (option2)
                    {
                        case 1:
                            Console.WriteLine("Title: ");
                            string bTitle = Console.ReadLine();
                            Console.WriteLine("Author: ");
                            string author = Console.ReadLine();
                            
                            param = new BookParamFactory(bTitle, author);
                            break;
                        case 2:
                            Console.WriteLine("Title: ");
                            string mTitle = Console.ReadLine();
                            Console.WriteLine("Number: ");
                            int number = int.Parse(Console.ReadLine()!);
                            
                            param = new MagazineParamFactory(mTitle, number);
                            break;
                    }
                    
                    if(param != null) library.AddElem(param);
                    break;
                
                case 2:
                    Console.WriteLine("Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Phone:");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Address:");
                    string address = Console.ReadLine();
                    
                    library.AddMember(name,phone,address);
                    break;
                case 3:
                    Console.WriteLine("Choose item to borrow:\n 1. Book\n 2. Magazine");
                    option3 = int.Parse(Console.ReadLine()!);
                    
                    Console.WriteLine("Enter member ID:");
                    int memberID = int.Parse(Console.ReadLine()!);
                    
                    if (option3 == 1) {
                        Console.WriteLine("Books:");
                        library.VisitBooks(showVisitor); 
                    } else {
                        Console.WriteLine("Magazines:");
                        library.VisitMagazines(showVisitor);
                    }
                    
                    Console.WriteLine("\nEnter item ID:");
                    int itemID = int.Parse(Console.ReadLine()!);
                    
                    library.BorrowElem(memberID, itemID);
                    break;
                case 4:
                    Console.WriteLine("Enter member ID:");
                    int memberID2 = int.Parse(Console.ReadLine()!);
                    
                    if (!library.HasBorrowedElem(memberID2)){ Console.WriteLine("Member has no borrowed elements."); break;}
                    else
                    {
                        Console.WriteLine("Borrowed elements:");
                        library.ShowBorrowedElems(memberID2);
                    }
                    
                    Console.WriteLine("Enter element ID:");
                    int elemID = int.Parse(Console.ReadLine()!);

                    library.ReturnElem(memberID2, elemID);
                    break;
                case 5:
                    Console.WriteLine("1. Show all");
                    Console.WriteLine("2. Show members");
                    Console.WriteLine("3. Show elements");
                    option2 = int.Parse(Console.ReadLine());
                    switch (option2)
                    {
                        case 1:
                            library.VisitMembers(showVisitor);
                            library.VisitElems(showVisitor);
                            break;
                        case 2:
                            library.VisitMembers(showVisitor);
                            break;
                        case 3:
                            library.VisitElems(showVisitor);
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                    break;
                case 6:
                    Console.WriteLine("Not implemented.");
                    break;
                case 7:
                    Console.WriteLine("Exiting...");
                    break; 
                
            }
            Menu();
            option = int.Parse(Console.ReadLine()!);
        }
    }

    private static void Menu()
    {
        Console.WriteLine("1. Add element");
        Console.WriteLine("2. Add member");
        Console.WriteLine("3. Borrow");
        Console.WriteLine("4. Return");
        Console.WriteLine("5. Show");
        Console.WriteLine("6. Retentions - NOT IMPLEMENTED");
        Console.WriteLine("7. Exit");
    }

    private static void Fill(Library lib)
    {
        //fill with members
        lib.AddMember("John", "123456789", "Street 1");
        lib.AddMember("Mary", "987654321", "Street 2");
        lib.AddMember("Peter", "123123123", "Street 3");
        lib.AddMember("Paul", "321321321", "Street 4");
        
        //fill with books
        lib.AddElem(new BookParamFactory("Ion", "Liviu Rebreanu"));
        lib.AddElem(new BookParamFactory("Morometii", "Marin Preda"));
        lib.AddElem(new BookParamFactory("Enigma Otiliei", "George Calinescu"));
        lib.AddElem(new BookParamFactory("Baltagul", "Mihail Sadoveanu"));
        
        //fill with magazines
        lib.AddElem(new MagazineParamFactory("Revista Click", 1884));
        lib.AddElem(new MagazineParamFactory("Revista Bravo", 2000));
        lib.AddElem(new MagazineParamFactory("Revista Viva", 2010));
        lib.AddElem(new MagazineParamFactory("Revista Elle", 2015));
        
        Console.WriteLine("\n\n\n\n\n\n\n\n");
    }
    
}
