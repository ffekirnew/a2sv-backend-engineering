using AutoMapper;
using CleanArchtectureBlogApi.Application.DTOs.Comment;
using CleanArchtectureBlogApi.Application.Features.Comments.Requests.Queries;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Handlers.Queries;

public class GetCommentDetailRequestHandler : IRequestHandler<GetCommentDetailRequest, CommentDto>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentDetailRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<CommentDto> Handle(
        GetCommentDetailRequest request,
        CancellationToken cancellationToken
    )
    {
        var comment = await _commentRepository.Get(request.Id);
        return _mapper.Map<CommentDto>(comment);
    }
}
