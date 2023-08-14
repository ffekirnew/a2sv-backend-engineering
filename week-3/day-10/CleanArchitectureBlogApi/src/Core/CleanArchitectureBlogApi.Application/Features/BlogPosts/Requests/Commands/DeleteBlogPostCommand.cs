using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;

public class DeleteBlogPostCommand : IRequest<int>
{
    public int Id { get; set; }
}
