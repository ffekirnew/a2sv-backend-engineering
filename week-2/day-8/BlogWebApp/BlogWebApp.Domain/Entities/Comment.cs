namespace BlogWebApp.Domain.Entities;

public class Comment : BaseEntity
{
    public int PostId { get; set; }
    public string Text { get; set; } = "";

    public virtual Post Post {get; set;}
}
