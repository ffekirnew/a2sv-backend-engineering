using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;

public class CreateBlogPostCommand : IRequest<int>
{
    public BlogPostCreateDto BlogPostCreateDto { get; set; } = null!;
}
