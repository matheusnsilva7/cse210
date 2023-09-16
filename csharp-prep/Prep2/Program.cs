using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage as a whole number? ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (grade >= 70)
        {
            Console.WriteLine($"Your grade is: {letter} (Congratulations, you passed!)");
        }
        else
        {
            Console.WriteLine($"Your grade is: {letter} (Keep it up for next time!)");
        }

    }
}