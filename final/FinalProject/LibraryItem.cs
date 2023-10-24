class LibraryItem
{
    public string _title;
    public string _author ;
    public int _publicationYear ;

    public LibraryItem(string title, string author, int publicationYear)
    {
        _title = title;
        _author = author;
        _publicationYear = publicationYear;
    }

    public virtual string GetDetails()
    {
        return $"Title: {_title}, Author: {_author}, Year: {_publicationYear}";
    }
}