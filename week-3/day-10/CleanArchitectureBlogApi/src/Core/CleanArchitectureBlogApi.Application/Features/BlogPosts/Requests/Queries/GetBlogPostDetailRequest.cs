using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Queries;

public class GetBlogPostDetailRequest : IRequest<BlogPostDto>
{
    public int Id { get; set; }
}
