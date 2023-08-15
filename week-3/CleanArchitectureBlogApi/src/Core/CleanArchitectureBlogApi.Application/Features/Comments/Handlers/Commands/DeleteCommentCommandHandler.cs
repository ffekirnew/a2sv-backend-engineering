using AutoMapper;
using CleanArchtectureBlogApi.Application.Features.Comments.Requests.Commands;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Handlers.Commands;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        DeleteCommentCommand request,
        CancellationToken cancellationToken
    )
    {
      await _commentRepository.Delete(request.Id);
        return Unit.Value;
    }
}
