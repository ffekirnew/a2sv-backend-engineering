using CleanArchtectureBlogApi.Application.DTOs.Common;

namespace CleanArchtectureBlogApi.Application.DTOs.BlogPost;

public class BlogPostDto : BaseDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
