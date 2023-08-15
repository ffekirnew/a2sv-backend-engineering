namespace CleanArchtectureBlogApi.Application.DTOs.BlogPost;

public class BlogPostUpdateDto : IBlogPostDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
