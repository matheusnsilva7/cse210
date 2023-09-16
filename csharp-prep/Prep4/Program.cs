using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished!");

        List<int> numbers = new List<int>();
        int number = 1;
        int sum = 0;
        int largest = 0;

        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        foreach (int num in numbers)
        {
            sum += num;
            if (largest < num)
            {
                largest = num;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {sum / numbers.Count}");
        Console.WriteLine($"The largest number is: {largest}");
    }
}