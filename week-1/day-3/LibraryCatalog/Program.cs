using LibraryCatalog.LibraryItems;
namespace LibraryCatalog;

class Program
{
  private Library MyLibrary;
  public static void Main()
  {
    Program program = new();
    program.Run();
  }

  public Program()
  {
    MyLibrary = new("A2SV Library", "Abrehot Library, 4 Kilo, Addis Ababa");

    MyLibrary.AddBook(new Book("Fikir Eske Mekabir", "Haddis Alemayehu", "978-99944-0-000-0", 1968));
    MyLibrary.AddBook(new Book("Ye'Gebreal W'et", "Haddis Alemayehu", "978-99944-0-000-1", 1970));
    MyLibrary.AddBook(new Book("Ye'Emnet W'et", "Haddis Alemayehu", "978-99944-0-000-2", 1971));
    MyLibrary.AddBook(new Book("Ye'Qine W'et", "Haddis Alemayehu", "978-99944-0-000-3", 1976));
    MyLibrary.AddBook(new Book("Ye'Nebiyat W'et", "Haddis Alemayehu", "978-99944-0-000-4", 1978));

    MyLibrary.AddMediaItem(new MediaItem("Difret", "Drama", 99));
    MyLibrary.AddMediaItem(new MediaItem("Lamb", "Drama", 94));
    MyLibrary.AddMediaItem(new MediaItem("Teza", "Drama", 140));
    MyLibrary.AddMediaItem(new MediaItem("Yefikir Kal", "Drama", 120));
    MyLibrary.AddMediaItem(new MediaItem("Yewededu Semon", "Drama", 120));
  }

  private void Run()
  {
    Console.WriteLine($"Welcome to the {MyLibrary.Name} Catalog!");
    UserMenu();
    Console.WriteLine($"Thank you for using our Library Catalog! Come visit us at {MyLibrary.Address} again soon!");
  }

  private void UserMenu()
  {
    Console.WriteLine("\nWhat would you like to do?");
    Console.WriteLine("| 1. Add a book \n| 2. Remove a book \n| 3. Add a media item \n| 4. Remove a media item \n| 5. List all items \n| 6. Search \n| 7. Exit");
    Console.Write("Enter your choice: ");


    int choice;
    while (!int.TryParse(Console.ReadLine()!, out choice))
    {
      Console.WriteLine("You need to enter a valid number from the choices. Please try again.");
      Console.Write("Enter your choice: ");
    }

    switch (choice)
    {
      case 1:
        AddBook();
        break;
      case 2:
        RemoveBook();
        break;
      case 3:
        AddMediaItem();
        break;
      case 4:
        RemoveMediaItem();
        break;
      case 5:
        Console.WriteLine("Here is a list of all the items in the catalog: ");
        MyLibrary.PrintCatalog();
        break;
      case 6:
        Search();
        break;
      case 7:
        return;
      default:
        Console.WriteLine("Invalid choice. Please try again.");
        break;
    }

    UserMenu();
  }

  private void AddBook()
  {
    Console.WriteLine("Enter the book's title, author, ISBN and year of publication separated by commas (e.g. Title, Author, ISBN, Year): ");
    string[] bookInfo = Console.ReadLine()!.Split(',');

    while (bookInfo.Length != 4)
    {
      Console.WriteLine("Invalid input. Please try again.");
      bookInfo = Console.ReadLine()!.Split(',');
    }

    try
    {
      MyLibrary.AddBook(new Book(bookInfo[0], bookInfo[1], bookInfo[2], int.Parse(bookInfo[3])));
      Console.WriteLine("Book added successfully!");
    }
    catch (ArgumentException e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private void RemoveBook()
  {
    Console.WriteLine("Enter the book's title, author, ISBN and year of publication separated by commas (e.g. Title, Author, ISBN, Year): ");
    string[] bookInfo = Console.ReadLine()!.Split(',');

    while (bookInfo.Length != 4)
    {
      Console.WriteLine("Invalid input. Please try again.");
      bookInfo = Console.ReadLine()!.Split(',');
    }

    try
    {
      MyLibrary.RemoveBook(new Book(bookInfo[0], bookInfo[1], bookInfo[2], int.Parse(bookInfo[3])));
      Console.WriteLine("Book removed successfully!");
    }
    catch (KeyNotFoundException e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private void AddMediaItem()
  {
    Console.WriteLine("Enter the media item's title, media type and duration separated by commas (e.g. Title, Media Type, Duration): ");
    string[] mediaItemInfo = Console.ReadLine()!.Split(',');

    while (mediaItemInfo.Length != 3)
    {
      Console.WriteLine("Invalid input. Please try again.");
      mediaItemInfo = Console.ReadLine()!.Split(',');
    }

    try
    {
      MyLibrary.AddMediaItem(new MediaItem(mediaItemInfo[0], mediaItemInfo[1], int.Parse(mediaItemInfo[2])));
      Console.WriteLine("Media item added successfully!");
    }
    catch (ArgumentException e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private void RemoveMediaItem()
  {
    Console.WriteLine("Enter the media item's title, media type and duration separated by commas (e.g. Title, Media Type, Duration): ");
    string[] mediaItemInfo = Console.ReadLine()!.Split(',');

    while (mediaItemInfo.Length != 3)
    {
      Console.WriteLine("Invalid input. Please try again.");
      mediaItemInfo = Console.ReadLine()!.Split(',');
    }

    try
    {
      MyLibrary.RemoveMediaItem(new MediaItem(mediaItemInfo[0], mediaItemInfo[1], int.Parse(mediaItemInfo[2])));
      Console.WriteLine("Media item removed successfully!");
    }
    catch (KeyNotFoundException e)
    {
      Console.WriteLine(e.Message);
    }
  }

  private void Search()
  {
    Console.WriteLine("Enter the any field of the item you want to search for: ");
    string field = Console.ReadLine()!;

    Console.WriteLine("Search results: ");
    MyLibrary.SearchCatalog(field);
  }
}
