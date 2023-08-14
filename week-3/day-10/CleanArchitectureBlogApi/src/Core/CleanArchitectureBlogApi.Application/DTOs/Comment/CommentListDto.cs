using CleanArchtectureBlogApi.Application.DTOs.Common;

namespace CleanArchtectureBlogApi.Application.DTOs.Comment;

public class CommentListDto : BaseDto
{
    public string Text { get; set; } = null!;
    public int PostId { get; set; }
}
