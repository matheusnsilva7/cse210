class Library
{
    private List<LibraryItem> items = new List<LibraryItem>();

    public void AddItem(LibraryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(LibraryItem item)
    {
        items.Remove(item);
    }

    public List<LibraryItem> ListItems()
    {
        return items;
    }
}