class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _endVerse;

    public Reference(string referenceText)
    {
        string[] parts = referenceText.Split(':', '-', ' ');
        _book = parts[0];
        _chapter = parts[1];
        _verse = parts[2];
        _endVerse = parts[3];
    }

    public string GetDisplayText()
    {
        if (_endVerse == "")
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}