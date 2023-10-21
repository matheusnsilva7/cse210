using System;

class Program
{
    static List<LibraryMember> libraryMembers = new List<LibraryMember>();
    static List<LibraryItem> libraryItems = new List<LibraryItem>();
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the Library Management System!");

        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Create a new account");
            Console.WriteLine("2. Log in");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice (1-3): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:

                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        LibraryMember newMember = new LibraryUser(name);
        libraryMembers.Add(newMember);
        Console.WriteLine($"Account created for {name}.");
    }



    static void ShowUserOptions(LibraryMember user)
    {
        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. List Available Items");
            Console.WriteLine("2. Borrow Item");
            Console.WriteLine("3. Return Item");
            Console.WriteLine("4. Log Out");
            Console.Write("Enter your choice (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        Console.WriteLine("Logged out.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
