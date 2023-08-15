using CleanArchtectureBlogApi.Application.DTOs.Comment;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Requests.Commands;

public class CreateCommentCommand : IRequest<int>
{
    public CommentCreateDto CommentCreateDto { get; set; } = null!;
}
