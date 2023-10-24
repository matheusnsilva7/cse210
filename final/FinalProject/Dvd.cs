class DVD : LibraryItem
{
    public string _director;
    public int _duration;

    public DVD(string title, string author, int publicationYear, string director, int duration)
        : base(title, author, publicationYear)
    {
        _director = director;
        _duration = duration;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $", Director: {_director}, Duration: {_duration}";
    }
}