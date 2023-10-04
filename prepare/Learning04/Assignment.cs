public class Assignments
{
    private string _studentName;
    private string _topic;

    public Assignments(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }
    
        public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }
    public string GetSummary()
    {
        return $"Name: {_studentName} , Topic: {_topic}";
    }
}