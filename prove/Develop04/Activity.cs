public abstract class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public abstract void Run();

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"{_name} - {_description}");
        Console.WriteLine("Prepare to begin in 3 seconds...");
        ShowCountDown(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Great job! You've completed the {_name} activity.");
        Console.WriteLine($"Duration: {_duration} seconds");
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Starting in {i}...");
            Thread.Sleep(1000);
        }
    }
}