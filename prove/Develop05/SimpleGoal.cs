class SimpleGoal : Goal
{
    public bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public bool GetIsCompleted()
    {
        return _isComplete;
    }

    public void SetIsCompleted(bool isCompleted)
    {
        _isComplete = isCompleted;
    }
    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"Simple Goal:{_name}-{_description}-{_points}-{_isComplete}";
    }
}