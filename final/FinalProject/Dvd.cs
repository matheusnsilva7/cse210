class DVD : LibraryItem
{
    private string Director;
    private int Duration;

    public DVD(string title, string author, int publicationYear, string director, int duration)
        : base(title, author, publicationYear)
    {
        Director = director;
        Duration = duration;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $", Director: {Director}, Duration: {Duration} minutes";
    }
}