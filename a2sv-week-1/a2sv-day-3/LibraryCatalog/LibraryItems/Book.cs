using LibraryCatalog.LibraryItems.Interfaces;
namespace LibraryCatalog.LibraryItems;

public class Book : ILibraryItem, ISearchableItem
{
    private string Title;
    private string Author;
    public string ISBN { get; }
    private int PublicationYear;

    public Book(string title, string author, string isbn, int publicationYear)
    {
        (Title, Author, ISBN, PublicationYear) = (title, author, isbn, publicationYear);
    }

    public override string ToString()
    {
        return $"{Title} by {Author} ({PublicationYear})";
    }

    public bool Matches(string query)
    {
        return Title.Contains(query) || Author.Contains(query) || ISBN.Contains(query);
    }
}