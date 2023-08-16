namespace CleanArchtectureBlogApi.Application.DTOs.Comment;

public class CommentUpdateDto : ICommentDto
{
    public string Text { get; set; } = null!;
    public int PostId { get; set; }
}
