using LibraryCatalog.LibraryItems;
namespace LibraryCatalog;

class Library
{
  public string Name { get; }
  public string Address { get; }
  private Dictionary<string, Book> Books = new();
  private Dictionary<string, MediaItem> MediaItems = new();

  public Library(string name, string address) => (Name, Address) = (name, address);

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

  public void AddMediaItem(MediaItem item)
  {
    try
    {
      string slug = item.GetSlug();
      MediaItems.Add(slug, item);
    }
    catch (ArgumentException)
    {
      throw new ArgumentException("Ths media item already exists in the catalog.");
    }
  }

  public void RemoveMediaItem(MediaItem item)
  {
    try
    {
      string slug = item.GetSlug();
      MediaItems.Remove(slug);
    }
    catch (KeyNotFoundException)
    {
      throw new KeyNotFoundException("The media item does not exist in the catalog.");
    }
  }

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
