public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(int duration) : base("Reflecting Activity", "Reflect on a past experience.", duration)
    {
        _prompts = new List<string>
        {
            "---Think of a time when you stood up for someone else.---",
            "---Think of a time when you did something really difficult.---",
            "---Think of a time when you helped someone in need.---",
            "---Think of a time when you did something truly selfless.---"
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        Thread.Sleep(5000);

        DisplayQuestions();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }

    private void DisplayQuestions()
    {
        foreach (var question in _questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(5000);
        }
    }

}