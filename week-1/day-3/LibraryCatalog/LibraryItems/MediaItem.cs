using LibraryCatalog.LibraryItems.Interfaces;
namespace LibraryCatalog.LibraryItems;

public class MediaItem : ILibraryItem, ISearchableItem
{
    private string Title;
    private string MediaType;
    private int Duration;

    // Add a constructor that does not take a slug
    public MediaItem(string title, string mediaType, int duration)
    {
        (Title, MediaType, Duration) = (title, mediaType, duration);
    }

    public override string ToString()
    {
        return $"{Title} ({MediaType}, {Duration} minutes)";
    }

    public string GetSlug()
    {
        return $"{Title}-{MediaType}-{Duration}";
    }

    public bool Matches(string query)
    {
        return Title.Contains(query) || MediaType.Contains(query);
    }
}