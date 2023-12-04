using Library.Models;
using Library.Utils.Factory;
using Library.Utils.Visitor;

namespace Library;

internal class Program
{
    private static void Main(string[] args)
    {
        var library = Library.Instance();

        Fill(library);

        var showVisitor = new ShowVisitor();
        Menu();

        int option3, option2, option = int.Parse(Console.ReadLine()!);

        while (option != 7)
        {
            switch (option)
            {
                case 1:
                    #region 1. Add element

                    Console.WriteLine("1. Book");
                    Console.WriteLine("2. Magazine");

                    option2 = int.Parse(Console.ReadLine()!);
                    ParamFactory param = null;

                    switch (option2)
                    {
                        case 1:
                            Console.WriteLine("Title: ");
                            var bTitle = Console.ReadLine();
                            Console.WriteLine("Author: ");
                            var author = Console.ReadLine();

                            param = new BookParamFactory(bTitle, author);
                            break;
                        case 2:
                            Console.WriteLine("Title: ");
                            var mTitle = Console.ReadLine();
                            Console.WriteLine("Number: ");
                            var number = int.Parse(Console.ReadLine()!);

                            param = new MagazineParamFactory(mTitle, number);
                            break;
                    }

                    if (param != null) library.AddElem(param);

                    #endregion
                    break;
                case 2:
                    #region 2. Add member
                    
                    Console.WriteLine("Name:");
                    var name = Console.ReadLine();
                    Console.WriteLine("Phone:");
                    var phone = Console.ReadLine();
                    Console.WriteLine("Address:");
                    var address = Console.ReadLine();

                    library.AddMember(name, phone, address);

                    #endregion
                    break;
                case 3:
                    #region 3. Borrow

                    Console.WriteLine("Choose item to borrow:\n 1. Book\n 2. Magazine");
                    option3 = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("Enter member ID:");
                    var memberID = int.Parse(Console.ReadLine()!);

                    if (option3 == 1)
                    {
                        Console.WriteLine("Books:");
                        library.VisitElems(showVisitor);
                    }
                    else
                    {
                        Console.WriteLine("Magazines:");
                        library.VisitElems(showVisitor);
                    }

                    Console.WriteLine("\nEnter item ID:");
                    var itemID = int.Parse(Console.ReadLine()!);
                    
                    Console.WriteLine("Borrow: \n1.In library\n2.At home");
                    option2 = int.Parse(Console.ReadLine()!);
                    
                    if (option2 == 1) library.BorrowElem(memberID, itemID, true);
                    else if (option2 == 2) library.BorrowElem(memberID, itemID, false);
                    else Console.WriteLine("Invalid option.");

                    #endregion
                    break;
                case 4:
                    #region 4. Return

                    Console.WriteLine("Enter member ID:");
                    var memberID2 = int.Parse(Console.ReadLine()!);

                    if (!library.HasBorrowedElem(memberID2))
                    {
                        Console.WriteLine("Member has no borrowed elements.");
                        break;
                    }

                    Console.WriteLine("Borrowed elements:");
                    library.VisitBorrowedElems(showVisitor, memberID2);

                    Console.WriteLine("Enter element ID:");
                    var elemID = int.Parse(Console.ReadLine()!);

                    library.ReturnElem(memberID2, elemID);

                    #endregion
                    break;
                case 5:
                    #region 5. Show

                    Console.WriteLine("1. Show all");
                    Console.WriteLine("2. Show members");
                    Console.WriteLine("3. Show elements");
                    Console.WriteLine("4. Show retentions");
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
                        case 4:
                            library.VisitRetention(showVisitor);
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                    #endregion
                    break;
                case 6:
                    #region 6. Retentions
                    
                    Console.WriteLine("1. Place retention");
                    Console.WriteLine("2. Cancel retention");
                    option2 = int.Parse(Console.ReadLine());
                    switch (option2)
                    {
                        case 1:
                            Console.WriteLine("Enter member ID:");
                            var memberID3 = int.Parse(Console.ReadLine()!);

                            Console.WriteLine("Enter element ID:");
                            var elemID2 = int.Parse(Console.ReadLine()!);

                            library.PlaceRetention(memberID3, elemID2);
                            break;
                        case 2:
                            Console.WriteLine("Enter member ID:");
                            var memberID4 = int.Parse(Console.ReadLine()!);

                            Console.WriteLine("Enter element ID:");
                            var elemID3 = int.Parse(Console.ReadLine()!);

                            library.CancelRetention(memberID4, elemID3);
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                    #endregion
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
        Console.WriteLine("6. Retentions");
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