namespace LibraryCatalog.LibraryItems.Interfaces;

public interface ISearchableItem
{
  public abstract bool Matches(string query);
}
