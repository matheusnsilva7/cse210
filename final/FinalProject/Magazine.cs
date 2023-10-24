class Magazine : LibraryItem
{
    public int _issueNumber;
    public string _publisher;

    public Magazine(string title, string author, int publicationYear, int issueNumber, string publisher)
        : base(title, author, publicationYear)
    {
        _issueNumber = issueNumber;
        _publisher = publisher;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $", Issue Number: {_issueNumber}, Publisher: {_publisher}";
    }
}