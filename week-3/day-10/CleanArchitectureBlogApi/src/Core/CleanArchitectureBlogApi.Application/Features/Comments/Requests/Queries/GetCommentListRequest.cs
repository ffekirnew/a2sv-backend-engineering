using CleanArchtectureBlogApi.Application.DTOs.Comment;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Requests.Queries;

public class GetCommentListRequest : IRequest<List<CommentListDto>>
{
    public int PostId { get; set; }
}
