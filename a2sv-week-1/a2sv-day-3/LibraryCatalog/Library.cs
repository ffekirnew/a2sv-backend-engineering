using LibraryCatalog.LibraryItems;
namespace LibraryCatalog;

class Library
{
    public string Name { get; }
    public string Address { get; }
    private Dictionary<string, Book> Books = new();
    private Dictionary<string, MediaItem> MediaItems = new();

    public Library(string name, string address) => (Name, Address) = (name, address);

    // `AddBook(Book book)`: Add a book to the library's collection.
    public void AddBook(Book book)
    {
        try
        {
            Books.Add(book.ISBN, book);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Ths book already exists in the catalog.");
        }
    }

    // `RemoveBook(Book book)`: Remove a book from the library's collection.
    public void RemoveBook(Book book)
    {
        try
        {
            Books.Remove(book.ISBN);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("The book does not exist in the catalog.");
        }
    }

    // `AddMediaItem(MediaItem item)`: Add a media item to the library's collection.
    public void AddMediaItem(MediaItem item)
    {
        try
        {
            // Create a slug from the title, mediaType and duration - this will be a unique identifier
            string slug = item.GetSlug();
            MediaItems.Add(slug, item);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Ths media item already exists in the catalog.");
        }
    }

    // `RemoveMediaItem(MediaItem item)`: Remove a media item from the library's collection.
    public void RemoveMediaItem(MediaItem item)
    {
        try
        {
            // Create a slug from the title, mediaType and duration - this will be a unique identifier
            string slug = item.GetSlug();
            MediaItems.Remove(slug);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("The media item does not exist in the catalog.");
        }
    }

    // `PrintCatalog()`: Print the list of books and media items in the library.
    public void PrintCatalog()
    {
        Console.WriteLine("Books:");
        foreach (Book book in Books.Values)
        {
            Console.WriteLine($"| {book}");
        }

        Console.WriteLine("Media Items:");
        foreach (MediaItem item in MediaItems.Values)
        {
            Console.WriteLine($"| {item}");
        }
    }

    // `SearchCatalog()`: Searh the library's catalog for a book or media item by title, author, ISBN, or media type.
    public void SearchCatalog(string query)
    {
        Console.WriteLine("Books:");
        foreach (Book book in Books.Values)
        {
            if (book.Matches(query))
            {
                Console.WriteLine($"| {book}");
            }
        }

        Console.WriteLine("Media Items:");
        foreach (MediaItem item in MediaItems.Values)
        {
            if (item.Matches(query))
            {
                Console.WriteLine($"| {item}");
            }
        }
    }

}