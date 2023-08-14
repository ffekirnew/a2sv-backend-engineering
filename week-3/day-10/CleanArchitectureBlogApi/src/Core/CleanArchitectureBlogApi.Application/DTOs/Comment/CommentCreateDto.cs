namespace CleanArchtectureBlogApi.Application.DTOs.Comment;

public class CommentCreateDto
{
    public string Text { get; set; } = null!;
    public int PostId { get; set; }
}
