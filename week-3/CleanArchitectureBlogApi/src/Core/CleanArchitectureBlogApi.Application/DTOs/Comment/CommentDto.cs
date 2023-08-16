using CleanArchtectureBlogApi.Application.DTOs.Common;

namespace CleanArchtectureBlogApi.Application.DTOs.Comment;

public class CommentDto : BaseDto, ICommentDto
{
    public string Text { get; set; } = null!;
    public int PostId { get; set; }
    public DateTime CreatedAt {get; set;}
}
