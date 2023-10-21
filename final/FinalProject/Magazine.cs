class Magazine : LibraryItem
{
    private int IssueNumber ;
    private string Publisher ;

    public Magazine(string title, string author, int publicationYear, int issueNumber, string publisher)
        : base(title, author, publicationYear)
    {
        IssueNumber = issueNumber;
        Publisher = publisher;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $", Issue Number: {IssueNumber}, Publisher: {Publisher}";
    }
}