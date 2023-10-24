class Library
{
    private List<LibraryItem> _items = new List<LibraryItem>();

    public void AddItem(LibraryItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(LibraryItem item)
    {
        _items.Remove(item);
    }

    public List<LibraryItem> ListItems()
    {
        return _items;
    }
}