class ChecklistGoal : Goal
{
    public int _amountCompleted;
    protected int _target;
    protected int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted == _target)
        {
            return _points + _bonus;
        }
        else
        {
            return _points;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetDetailsString()
    { 
        return  $"[{(IsComplete() ? "X" : " ")}] {_name} - {_description} -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        return $"Checklist Goal:{_name}-{_description}-{_points}-{_amountCompleted}-{_target}-{_bonus}";
    }
}