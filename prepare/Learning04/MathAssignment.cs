public class MathAssignment : Assignments
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment (string name , string topic,string text , string problems) : base(name,topic)
    {
        _textbookSection = text;
        _problems = problems;
    }

    public string GetHomeworkList(){
        return $"{GetSummary()}\nSection: {_textbookSection} problems: {_problems}";
    }
}