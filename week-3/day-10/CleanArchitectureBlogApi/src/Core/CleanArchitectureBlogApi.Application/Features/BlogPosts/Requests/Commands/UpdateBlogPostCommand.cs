using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;

public class UpdateBlogPostCommand : IRequest<int>
{
    public int Id { get; set; }
    public BlogPostDto BlogPostDto { get; set; } = null!;
}
