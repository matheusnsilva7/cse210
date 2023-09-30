using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string scriptureFilePath;

        Console.WriteLine("Welcome to the Scripture Memorizer!");

        while (true)
        {
            Console.Write("Enter the file path for the scripture (scripture.txt): ");
            scriptureFilePath = Console.ReadLine();

            if (File.Exists(scriptureFilePath))
            {
                break;
            }
            else
            {
                Console.WriteLine("Error: The provided scripture file does not exist. Please try again.");
            }
        }

        Console.WriteLine("Press Enter to reveal the scripture or type 'quit' to exit.");

        Scripture scripture = new Scripture(scriptureFilePath);

        while (true)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else if (input == "")
            {
                scripture.HideRandomWords(2);
                DisplayScripture(scripture);
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to reveal or type 'quit' to exit.");
            }
        }
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
    }
}