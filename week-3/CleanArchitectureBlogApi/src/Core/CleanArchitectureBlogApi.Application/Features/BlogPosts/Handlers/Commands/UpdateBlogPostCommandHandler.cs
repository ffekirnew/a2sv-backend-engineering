using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.DTOs.BlogPost.Validators;
using CleanArchtectureBlogApi.Application.Exceptions;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Handlers.Commands;

public class UpdateBlogPostCommandHandler : IRequestHandler<UpdateBlogPostCommand, Unit>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public UpdateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        UpdateBlogPostCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new BlogPostUpdateDtoValidator();
        var validationResult = dtoValidator.Validate(request.BlogPostUpdateDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);
        var blogPost = _mapper.Map<BlogPost>(request.BlogPostUpdateDto);

        await _blogPostRepository.Update(request.Id, blogPost);

        return Unit.Value;
    }
}
