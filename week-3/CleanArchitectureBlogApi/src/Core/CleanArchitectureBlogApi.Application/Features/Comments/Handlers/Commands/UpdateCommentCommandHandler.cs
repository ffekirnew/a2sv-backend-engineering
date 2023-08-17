using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.DTOs.Comment.Validators;
using CleanArchtectureBlogApi.Application.Exceptions;
using CleanArchtectureBlogApi.Application.Features.Comments.Requests.Commands;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.Comments.Handlers.Commands;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IBlogPostRepository _blogPostRepository;

    public UpdateCommentCommandHandler(
        ICommentRepository commentRepository,
        IBlogPostRepository blogPostRepository,
        IMapper mapper
    )
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _blogPostRepository = blogPostRepository;
    }

    public async Task<Unit> Handle(
        UpdateCommentCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new CommentUpdateDtoValidator(_blogPostRepository);
        var validationResult = dtoValidator.Validate(request.CommentUpdateDto);

        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        var comment = _mapper.Map<Comment>(request.CommentUpdateDto);
        comment.Id = request.Id;
        await _commentRepository.Update(request.Id, comment);

        return Unit.Value;
    }
}
