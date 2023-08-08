namespace BlogApp.Domain.Entities;

public class Comment : BaseEntity
{
    private int postId;
    private string text = "";

    public int PostId
    {
        get => postId;
        set => postId = value;
    }

    public string Text
    {
        get => text;
        set => text = value;
    }

    public virtual Post? Post { get; set; }

    public override string ToString() => $"Post Id: {PostId}, {Id}. {Text}";
}
