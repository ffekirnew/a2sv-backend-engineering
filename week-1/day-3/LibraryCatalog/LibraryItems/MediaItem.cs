using LibraryCatalog.LibraryItems.Interfaces;
namespace LibraryCatalog.LibraryItems;

public class MediaItem : ILibraryItem, ISearchableItem
{
  private string Title;
  private string MediaType;
  private int Duration;

  public MediaItem(string title, string mediaType, int duration)
  {
    (Title, MediaType, Duration) = (title, mediaType, duration);
  }

  public override string ToString() => $"{Title} ({MediaType}, {Duration} minutes)";

  public string GetSlug() => $"{Title}-{MediaType}-{Duration}";

  public bool Matches(string query) => Title.Contains(query) || MediaType.Contains(query);
}
