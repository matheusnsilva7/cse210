class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }

    public LibraryItem(string title, string author, int publicationYear)
    {
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
    }

    public virtual string GetDetails()
    {
        return $"Title: {Title}, Author: {Author}, Year: {PublicationYear}";
    }
}