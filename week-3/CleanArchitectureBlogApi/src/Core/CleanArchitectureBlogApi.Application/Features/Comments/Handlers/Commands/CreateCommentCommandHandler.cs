using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.DTOs.Common.Validators;
using CleanArchtectureBlogApi.Application.Features.Comments.Requests.Commands;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;

    public CreateCommentCommandHandler(
        ICommentRepository commentRepository,
        IMapper mapper,
        IBlogPostRepository blogPostRepository
    )
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var dtoValidator = new CommentCreateDtoValidator(_blogPostRepository);
        var validationResult = dtoValidator.Validate(request.CommentCreateDto);

        if (!validationResult.IsValid)
            throw new Exception();
        var comment = _mapper.Map<Comment>(request.CommentCreateDto);
        comment = await _commentRepository.Create(comment);

        return comment.Id;
    }
}
