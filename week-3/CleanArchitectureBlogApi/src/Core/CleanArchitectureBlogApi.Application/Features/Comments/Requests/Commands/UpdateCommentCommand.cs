using CleanArchtectureBlogApi.Application.DTOs.Comment;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Requests.Commands;

public class UpdateCommentCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public CommentUpdateDto CommentUpdateDto { get; set; } = null!;
}
