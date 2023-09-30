using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Press Enter to reveal the scripture or type 'quit' to exit.");

        Scripture scripture = new Scripture("scripture.txt");

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