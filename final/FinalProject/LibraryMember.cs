class LibraryMember
{
    protected string _Name;
    protected List<LibraryItem> _BorrowedItems;

    public LibraryMember(string name)
    {
        _Name = name;
        _BorrowedItems = new List<LibraryItem>();
    }

    public void BorrowItem(LibraryItem item)
    {
        _BorrowedItems.Add(item);
    }

    public void ReturnItem(LibraryItem item)
    {
        _BorrowedItems.Remove(item);
    }
}