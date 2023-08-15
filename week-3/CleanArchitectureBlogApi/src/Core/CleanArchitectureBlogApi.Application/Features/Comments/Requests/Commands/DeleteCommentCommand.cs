using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Requests.Commands;

public class DeleteCommentCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
