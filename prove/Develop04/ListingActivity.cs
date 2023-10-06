public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity(int duration) : base("Listing Activity", "Reflect on the good things in your life.", duration)
    {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine(GetRandomPrompt());
        Thread.Sleep(4000);

        _count = GetListFromUser();
        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private int GetListFromUser()
    {
        while (_duration > 0)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            _duration -= item.Length;
            _count++;
        }
        return _count;
    }
}