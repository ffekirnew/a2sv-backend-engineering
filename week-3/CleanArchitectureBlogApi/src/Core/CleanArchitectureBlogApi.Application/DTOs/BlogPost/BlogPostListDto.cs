using CleanArchtectureBlogApi.Application.DTOs.Common;

namespace CleanArchtectureBlogApi.Application.DTOs.BlogPost;

public class BlogPostListDto : BaseDto, IBlogPostDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
