class Book : LibraryItem
{
    public string _ISBN { get; set; }
    public string _genre { get; set; }

    public Book(string title, string author, int publicationYear, string isbn, string genre)
        : base(title, author, publicationYear)
    {
        _ISBN = isbn;
        _genre = genre;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $", ISBN: {_ISBN}, Genre: {_genre}";
    }
}