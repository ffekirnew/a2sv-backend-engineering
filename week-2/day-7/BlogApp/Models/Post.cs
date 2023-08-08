namespace BlogApp.Models;

class Post : BaseEntity
{
    private string title = "";
    private string content = "";
    private DateTime createdAt;

    public string Title
    {
        get => title;
        set => title = value;
    }
    public string Content
    {
        get => content;
        set => content = value;
    }

    public virtual ICollection<Comment> Comments { get; set; }

    public Post()
    {
        Comments = new HashSet<Comment>();
    }

    public override string ToString() => $"{Id}. {Title} - {CreatedAt}";
}
