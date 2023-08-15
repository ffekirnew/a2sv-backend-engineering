namespace CleanArchtectureBlogApi.Application.DTOs.BlogPost;

public class BlogPostCreateDto : IBlogPostDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
