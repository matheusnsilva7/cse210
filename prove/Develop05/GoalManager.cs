class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nEternal Quest Menu");
            Console.WriteLine("1. Display Score");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create Goal");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");

            int option = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (option)
            {
                case 1:
                    DisplayPlayerInfo();
                    break;
                case 2:
                    ListGoalNames();
                    break;
                case 3:
                    ListGoalDetails();
                    break;
                case 4:
                    CreateGoal();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    SaveGoals();
                    break;
                case 7:
                    LoadGoals();
                    break;
                case 8:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Your_Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goal Names:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetName());
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.Write("Enter Goal Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Goal Description: ");
        string description = Console.ReadLine();
        Console.Write("Enter Goal Points: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        int goalType = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case 1:
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.Write("Enter Target: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid option. Goal not created.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a Goal to Record Event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            int pointsEarned = goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Event recorded for {goals[goalIndex].GetName()}. You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved to file.");
    }

    public void LoadGoals()
    {
        goals.Clear();

        string[] lines = File.ReadAllLines("goals.txt");

        _score = int.Parse(lines[0]);
        string _goalType;
        string _goal;

        foreach (string line in lines)
        {
            if (line == lines[0]) continue;
            string[] firstPass = line.Split(":");
            _goalType = firstPass[0];
            _goal = firstPass[1];

            string[] secondPass = _goal.Split("-");

            string name = secondPass[0];
            string description = secondPass[1];
            int points = int.Parse(secondPass[2]);
            int amountCompleted = 0;
            int target = 0;
            int bonus = 0;

            if (_goalType == "Simple Goal")
            {
                bool isCompleted = bool.Parse(secondPass[3]);
                goals.Add(new SimpleGoal(name, description, points) { _isComplete = isCompleted });
            }
            else if (_goalType == "Eternal Goal")
            {
                goals.Add(new EternalGoal(name, description, points));
            }
            else if (_goalType == "Checklist Goal")
            {
                amountCompleted = int.Parse(secondPass[3]);
                target = int.Parse(secondPass[4]);
                bonus = int.Parse(secondPass[5]);
                goals.Add(new ChecklistGoal(name, description, points, target, bonus) { _amountCompleted = amountCompleted });
            }
        }
        Console.WriteLine("Goals loaded from file.");
    }
}