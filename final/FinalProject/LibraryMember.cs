class LibraryMember
{
    protected string _name;
    protected List<LibraryItem> _borrowedItems;

    public LibraryMember(string name)
    {
        _name = name;
        _borrowedItems = new List<LibraryItem>();
    }

    public string GetName()
    {
        return _name;
    }

    public void BorrowItem(LibraryItem item)
    {
        _borrowedItems.Add(item);
    }

    public void ReturnItem(LibraryItem item)
    {
        _borrowedItems.Remove(item);
    }
}