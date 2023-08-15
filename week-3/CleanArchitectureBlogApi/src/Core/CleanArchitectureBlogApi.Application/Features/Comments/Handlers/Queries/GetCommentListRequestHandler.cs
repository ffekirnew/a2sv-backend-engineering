using AutoMapper;
using CleanArchtectureBlogApi.Application.DTOs.Comment;
using CleanArchtectureBlogApi.Application.Features.Comments.Requests.Queries;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Handlers.Queries;

public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest, List<CommentListDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentListRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentListDto>> Handle(
        GetCommentListRequest request,
        CancellationToken cancellationToken
    )
    {
        var comments = await _commentRepository.GetAll(request.PostId);
        return _mapper.Map<List<CommentListDto>>(comments);
    }
}
