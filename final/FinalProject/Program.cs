using System;

class Program
{
    static List<LibraryMember> libraryMembers = new List<LibraryMember>();
    static List<LibraryItem> libraryItems = new List<LibraryItem>();

    static string membersFilePath = "LibraryMembers.txt";
    static string itemsFilePath = "LibraryItems.txt";
    static void Main(string[] args)
    {
        LoadLibraryMembersFromFile();
        LoadLibraryItemsFromFile();
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
                        LogIn();
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

    static void LoadLibraryMembersFromFile()
    {
        if (File.Exists(membersFilePath))
        {
            string[] lines = File.ReadAllLines(membersFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string name = parts[0];
                    string memberType = parts[1];

                    if (memberType == "LibraryUser")
                    {
                        LibraryMember newMember = new LibraryUser(name);
                        libraryMembers.Add(newMember);
                    }
                    else if (memberType == "LibraryStaff")
                    {
                        LibraryMember newMember = new LibraryStaff(name);
                        libraryMembers.Add(newMember);
                    }
                }
            }
        }
    }

    static void LoadLibraryItemsFromFile()
    {
        if (File.Exists(itemsFilePath))
        {
            string[] lines = File.ReadAllLines(itemsFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length >= 4)
                {
                    string itemType = parts[5];
                    string title = parts[0];
                    string authorDirectorArtist = parts[1];
                    string yearPart = parts[2].Substring("Year: ".Length);
                    if (int.TryParse(yearPart, out int publicationYear))
                    {
                        LibraryItem newItem = null;

                        if (itemType == "Book")
                        {
                            string isbn = parts[3];
                            string genre = parts[4];
                            newItem = new Book(title.Split(" ")[1], authorDirectorArtist.Split(" ")[1], publicationYear, isbn.Split(" ")[1], genre.Split(" ")[1]);
                        }
                        else if (itemType == "DVD")
                        {
                            string director = parts[4];
                            int duration;
                            if (int.TryParse(parts[5], out duration))
                            {
                                newItem = new DVD(title.Split(" ")[1], authorDirectorArtist.Split(" ")[1], publicationYear, director.Split(" ")[1], duration);
                            }
                        }
                        else if (itemType == "Magazine")
                        {
                            int issueNumber;
                            if (int.TryParse(parts[4], out issueNumber))
                            {
                                string publisher = parts[5];
                                newItem = new Magazine(title.Split(" ")[1], authorDirectorArtist.Split(" ")[1], publicationYear, issueNumber, publisher.Split(" ")[1]);
                            }
                        }

                        if (newItem != null)
                        {
                            libraryItems.Add(newItem);
                        }
                    }
                }
            }
        }
    }


    static void SaveLibraryMembersToFile()
    {
        using (StreamWriter writer = new StreamWriter(membersFilePath))
        {
            foreach (LibraryMember member in libraryMembers)
            {
                writer.WriteLine($"{member.GetName()},{member.GetType().Name}");
            }
        }
    }

    static void SaveLibraryItemsToFile()
    {
        using (StreamWriter writer = new StreamWriter(itemsFilePath))
        {
            foreach (LibraryItem item in libraryItems)
            {
                writer.WriteLine($"{item.GetDetails()},{item.GetType().Name}");
            }
        }
    }

    static void CreateAccount()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Select your role:");
        Console.WriteLine("1. Library User");
        Console.WriteLine("2. Library Staff");
        Console.Write("Enter your choice (1-2): ");

        if (int.TryParse(Console.ReadLine(), out int roleChoice))
        {
            LibraryMember newMember;

            if (roleChoice == 1)
            {
                newMember = new LibraryUser(name);
            }
            else if (roleChoice == 2)
            {
                newMember = new LibraryStaff(name);
            }
            else
            {
                Console.WriteLine("Invalid choice. A default Library User account will be created.");
                newMember = new LibraryUser(name);
            }

            libraryMembers.Add(newMember);
            Console.WriteLine($"Account created for {name} as a {newMember.GetType().Name}.");
            SaveLibraryMembersToFile();
            Console.WriteLine();
            Console.WriteLine("Login");
            LogIn();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    static void AddNewLibraryItem()
    {
        Console.Write("Enter the title of the item: ");
        string title = Console.ReadLine();
        Console.Write("Enter the author/director/artist of the item: ");
        string authorDirectorArtist = Console.ReadLine();
        Console.Write("Enter the publication year: ");
        if (!int.TryParse(Console.ReadLine(), out int publicationYear))
        {
            Console.WriteLine("Invalid input for publication year. Please enter a valid year.");
            return;
        }

        Console.WriteLine("Select the item type:");
        Console.WriteLine("1. Book");
        Console.WriteLine("2. DVD");
        Console.WriteLine("3. Magazine");
        Console.Write("Enter your choice (1-3): ");

        if (int.TryParse(Console.ReadLine(), out int itemTypeChoice))
        {
            LibraryItem newItem = null;

            switch (itemTypeChoice)
            {
                case 1:
                    Console.Write("Enter the genre of the DVD: ");
                    string genre = Console.ReadLine();
                    Console.Write("Enter the isbn of the DVD: ");
                    string isbn = Console.ReadLine();
                    newItem = new Book(title, authorDirectorArtist, publicationYear, isbn, genre);
                    break;
                case 2:
                    Console.Write("Enter the director of the DVD: ");
                    string director = Console.ReadLine();
                    Console.Write("Enter the duration of the DVD: ");
                    if (!int.TryParse(Console.ReadLine(), out int duration))
                    {
                        Console.WriteLine("Invalid input for duration. Please enter a valid duration.");
                        return;
                    }
                    newItem = new DVD(title, authorDirectorArtist, publicationYear, director, duration);
                    break;
                case 3:
                    Console.Write("Enter the issue number of the Magazine: ");
                    if (!int.TryParse(Console.ReadLine(), out int issueNumber))
                    {
                        Console.WriteLine("Invalid input for issue number. Please enter a valid issue number.");
                        return;
                    }
                    Console.Write("Enter the publisher of the Magazine: ");
                    string publisher = Console.ReadLine();
                    newItem = new Magazine(title, authorDirectorArtist, publicationYear, issueNumber, publisher);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }

            if (newItem != null)
            {
                libraryItems.Add(newItem);
                Console.WriteLine("Item added successfully.");
                SaveLibraryItemsToFile();
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    static void ListAvailableItems()
    {
        Console.WriteLine("Available Library Items:");

        foreach (LibraryItem item in libraryItems)
        {
            Console.WriteLine($"Title: {item._title}");
            Console.WriteLine($"Author: {item._author}");
            Console.WriteLine($"Year: {item._publicationYear}");

            if (item is Book book)
            {
                Console.WriteLine($"ISBN: {book._ISBN}");
                Console.WriteLine($"Genre: {book._genre}");
            }
            else if (item is DVD dvd)
            {
                Console.WriteLine($"Director: {dvd._director}");
                Console.WriteLine($"Duration: {dvd._duration}");
            }
            else if (item is Magazine magazine)
            {
                Console.WriteLine($"IssueNumber: {magazine._issueNumber}");
                Console.WriteLine($"Publisher: {magazine._publisher}");
            }

            Console.WriteLine();
        }
    }

    static void BorrowItem(LibraryMember user)
    {
        Console.Write("Enter the title of the item you want to borrow: ");
        string titleToBorrow = Console.ReadLine();

        LibraryItem itemToBorrow = libraryItems
        .FirstOrDefault(item => item._title.Equals(titleToBorrow, StringComparison.OrdinalIgnoreCase));

        if (itemToBorrow != null)
        {

            user.BorrowItem(itemToBorrow);
            Console.WriteLine($"You have successfully borrowed '{itemToBorrow._title}'.");
            SaveLibraryItemsToFile();
        }
        else
        {
            Console.WriteLine($"The item with title '{titleToBorrow}' is either not available or does not exist in the library.");
        }
    }


    static void ReturnItem(LibraryMember user)
    {
        Console.Write("Enter the title of the item you want to return: ");
        string titleToReturn = Console.ReadLine();

        LibraryItem itemToReturn = libraryItems
        .FirstOrDefault(item => item._title.Equals(titleToReturn, StringComparison.OrdinalIgnoreCase));

        if (itemToReturn != null)
        {
            // Return the item
            user.ReturnItem(itemToReturn);
            Console.WriteLine($"You have successfully returned '{itemToReturn._title}'.");
            SaveLibraryItemsToFile();
        }
        else
        {
            Console.WriteLine($"The item with title '{titleToReturn}' is either not borrowed by you or does not exist in the library.");
        }
    }
    static void LogIn()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        LibraryMember user = libraryMembers.Find(member => member.GetName() == name);

        if (user != null)
        {
            Console.WriteLine($"Welcome, {user.GetName()}!");
            ShowUserOptions(user);
        }
        else
        {
            Console.WriteLine("User not found. Please create an account or enter the correct name.");
        }
    }

    static void ShowUserOptions(LibraryMember user)
    {
        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. List Available Items");
            Console.WriteLine("2. Borrow Item");
            Console.WriteLine("3. Return Item");

            if (user is LibraryStaff)
            {
                Console.WriteLine("4. Add New Library Item");
            }

            Console.WriteLine("5. Log Out");
            Console.Write("Enter your choice (1-5): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ListAvailableItems();
                        break;
                    case 2:
                        BorrowItem(user);
                        break;
                    case 3:
                        ReturnItem(user);
                        break;
                    case 4:
                        if (user is LibraryStaff)
                        {
                            AddNewLibraryItem();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Logged out.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
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
