public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base("Breathing Activity", "Relax by focusing on your breath.", duration)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        for (int i = 0; i < _duration; i++)
        {
            string breathingText = i % 2 == 0 ? "Breathe in" : "Breathe out";
            string dots = new string('.', i + 1);
            Console.WriteLine($"{breathingText} {dots}");
            Thread.Sleep(3000);
        }
        DisplayEndingMessage();
    }
}
