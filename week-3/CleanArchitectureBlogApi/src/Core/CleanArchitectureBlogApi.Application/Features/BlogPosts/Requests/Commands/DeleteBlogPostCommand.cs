using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;

public class DeleteBlogPostCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
