class LibraryItem
{
    public string Title;
    public string Author ;
    public int PublicationYear ;

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