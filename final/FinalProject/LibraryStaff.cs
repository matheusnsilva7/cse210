class LibraryStaff : LibraryMember
{
    public LibraryStaff(string name) : base(name) { }

    public void AddLibraryItem(LibraryItem item, Library library)
    {
        library.AddItem(item);
    }

    public void RemoveLibraryItem(LibraryItem item, Library library)
    {
        library.RemoveItem(item);
    }
}