class Book : LibraryItem
{
    public string ISBN { get; set; }
    public string Genre { get; set; }

    public Book(string title, string author, int publicationYear, string isbn, string genre)
        : base(title, author, publicationYear)
    {
        ISBN = isbn;
        Genre = genre;
    }

    public override string GetDetails()
    {
        return base.GetDetails() + $", ISBN: {ISBN}, Genre: {Genre}";
    }
}