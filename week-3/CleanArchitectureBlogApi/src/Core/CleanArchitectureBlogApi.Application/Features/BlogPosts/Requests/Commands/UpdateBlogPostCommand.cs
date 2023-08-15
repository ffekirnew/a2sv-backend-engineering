using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;

public class UpdateBlogPostCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public BlogPostUpdateDto BlogPostUpdateDto { get; set; } = null!;
}
