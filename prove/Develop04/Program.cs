using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");

        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice == 4)
                {
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    break;
                }

                Console.Write("Enter the duration (in seconds): ");
                int duration = int.Parse(Console.ReadLine());

                Activity activity = null;
                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity(duration);
                        break;
                    case 2:
                        activity = new ReflectingActivity(duration);
                        break;
                    case 3:
                        activity = new ListingActivity(duration);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid activity.");
                        break;
                }

                if (activity != null)
                {
                    activity.Run();
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}