class LibraryCatalog
{
    private List<LibraryItem> catalog = new List<LibraryItem>();

    public void AddItemToCatalog(LibraryItem item)
    {
        catalog.Add(item);
    }

    public void RemoveItemFromCatalog(LibraryItem item)
    {
        catalog.Remove(item);
    }

    public List<LibraryItem> SearchByTitle(string title)
    {
        return catalog.FindAll(item => item.Title.Contains(title));
    }

    public List<LibraryItem> SearchByAuthor(string author)
    {
        return catalog.FindAll(item => item.Author.Contains(author));
    }

    public List<LibraryItem> SearchByGenre(string genre)
    {
        return catalog.FindAll(item => item is Book && ((Book)item).Genre.Contains(genre));
    }

    public List<LibraryItem> FilterAvailableItems(Library library)
    {
        var borrowedItems = new HashSet<LibraryItem>(library.ListItems());
        return catalog.FindAll(item => !borrowedItems.Contains(item));
    }
}