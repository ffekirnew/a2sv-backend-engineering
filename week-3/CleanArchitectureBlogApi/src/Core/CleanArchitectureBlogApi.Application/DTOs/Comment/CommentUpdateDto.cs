namespace CleanArchtectureBlogApi.Application.DTOs.Comment;

public class CommentUpdateDto
{
    public string Text { get; set; } = null!;
    public int PostId { get; set; }
}
