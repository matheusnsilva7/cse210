class Scripture
{
    private Reference _reference;
    private List<Word> _words;

     public Scripture(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        _reference = new Reference(lines[0]);

        string text = string.Join(" ", lines.Skip(1));

        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < numberToHide; i++)
        {
            if (visibleWords.Count > 0)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n\n";
        displayText += string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}