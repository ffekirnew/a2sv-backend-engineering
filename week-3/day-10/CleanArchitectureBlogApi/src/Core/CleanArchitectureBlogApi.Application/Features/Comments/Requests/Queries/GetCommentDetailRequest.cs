using CleanArchtectureBlogApi.Application.DTOs.Comment;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Requests.Queries;

public class GetCommentDetailRequest : IRequest<CommentDto>
{
    public int Id { get; set; }
}
