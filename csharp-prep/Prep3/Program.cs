using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the magic number! ");

        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1, 101);
        int guess = 0;

         while (guess != magic)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > magic)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magic)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}