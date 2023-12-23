using Library.Models;
using Library.Utils.Factory;
using Library.Utils.Visitor;

namespace Library;

public class Program
{
    private static void Main(string[] args)
    {
        var library = Library.Instance();
        var showVisitor = new ShowVisitor();
        Fill(library);
        
        Menu();
        int option3, option2, option = int.Parse(Console.ReadLine()!);

        while (option != 8)
        {
            switch (option)
            {
                case 1:
                    #region 1. Add element and member
                    Console.WriteLine("Choose what to add:");
                    Console.WriteLine("1. Element");
                    Console.WriteLine("2. Member");
                    
                    option3 = int.Parse(Console.ReadLine()!);

                    switch (option3)
                    {
                        case 1:

                            #region Add element
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
                                    Console.WriteLine("In room: (1 - Yes; 0 - No)");
                                    var bInRoom = int.Parse(Console.ReadLine()!);
                                    Console.WriteLine("With tax: (0 - Without tax)");
                                    var bWithTax = float.Parse(Console.ReadLine()!);

                                    param = new BookParamFactory(bTitle, author, bInRoom, bWithTax);
                                    break;
                                case 2:
                                    Console.WriteLine("Title: ");
                                    var mTitle = Console.ReadLine();
                                    Console.WriteLine("Number: ");
                                    var number = int.Parse(Console.ReadLine()!);
                                    Console.WriteLine("In room: (1 - Yes; 0 - No)");
                                    var mInRoom = int.Parse(Console.ReadLine()!);
                                    Console.WriteLine("With tax: (0 - Without tax)");
                                    var mWithTax = float.Parse(Console.ReadLine()!);

                                    param = new MagazineParamFactory(mTitle, number, mInRoom, mWithTax);
                                    break;
                            }

                            if (param != null) library.AddElement(param);
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
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                    

                    #endregion
                    break;
                case 2:
                    #region 2. Delete element and member
                    
                    Console.WriteLine("Choose what to delete:");
                    Console.WriteLine("1. Element");
                    Console.WriteLine("2. Member");
                    
                    option3 = int.Parse(Console.ReadLine()!);
                    
                    switch (option3)
                    {
                        case 1:
                            #region 1. Delete element
                            Console.WriteLine("1. Book");
                            Console.WriteLine("2. Magazine");

                            option2 = int.Parse(Console.ReadLine()!);
                            int elem = 0;
                            switch (option2)
                            {
                                case 1:
                                    Console.WriteLine("Books:");
                                    library.VisitElems(showVisitor);
                                    Console.WriteLine("Enter book ID:");
                                    elem = int.Parse(Console.ReadLine()!);
                                    break;
                                case 2:
                                    Console.WriteLine("Magazines:");
                                    library.VisitElems(showVisitor);
                                    Console.WriteLine("Enter magazine ID:");
                                    elem = int.Parse(Console.ReadLine()!);
                                    break;
                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }

                            if (elem != 0) library.DeleteElem(elem);
                            else Console.WriteLine("Invalid option.");
                            #endregion
                            break;
                        case 2:
                            #region 2. Delete member
                            Console.WriteLine("Members:");
                            library.VisitMembers(showVisitor);
                            Console.WriteLine("Enter member ID:");
                            var member_ID = int.Parse(Console.ReadLine()!);
                            library.DeleteMember(member_ID);
                            #endregion
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                    
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
                        library.VisitAvailableBooks(showVisitor);
                    }
                    else
                    {
                        Console.WriteLine("Magazines:");
                        library.VisitAvailableMagazines(showVisitor);
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

                    #region Show Transactions
                    
                    library.ShowTransactions();

                    #endregion
                    break;
                case 8:
                    Console.WriteLine("Exiting...");
                    break;
            }

            Menu();
            option = int.Parse(Console.ReadLine()!);
        }
    }

    private static void Menu()
    {
        Console.WriteLine("1. Add element or member");
        Console.WriteLine("2. Delete element or member");
        Console.WriteLine("3. Borrow");
        Console.WriteLine("4. Return");
        Console.WriteLine("5. Show");
        Console.WriteLine("6. Retentions");
        Console.WriteLine("7. Show transactions");
        Console.WriteLine("8. Exit");
    }

    private static void Fill(Library lib)
    {
        //fill with members
        lib.AddMember("John", "123456789", "Street 1");
        lib.AddMember("Mary", "987654321", "Street 2");
        lib.AddMember("Peter", "123123123", "Street 3");
        lib.AddMember("Paul", "321321321", "Street 4");

        //fill with books
        lib.AddElement(new BookParamFactory("Ion", "Liviu Rebreanu", 1, 0));
        lib.AddElement(new BookParamFactory("Morometii", "Marin Preda", 0, 12));
        lib.AddElement(new BookParamFactory("Enigma Otiliei", "George Calinescu", 1, 505));
        lib.AddElement(new BookParamFactory("Baltagul", "Mihail Sadoveanu", 0, 0));

        //fill with magazines
        lib.AddElement(new MagazineParamFactory("Revista Click", 1884, 0, 0));
        lib.AddElement(new MagazineParamFactory("Revista Bravo", 2000, 0, 0));
        lib.AddElement(new MagazineParamFactory("Revista Viva", 2010, 0, 0));
        lib.AddElement(new MagazineParamFactory("Revista Elle", 2015, 0, 0));

        Console.WriteLine("\n\n\n\n\n\n\n\n");
    }
}