using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.DTOs.BlogPost.Validators;
using CleanArchtectureBlogApi.Application.Exceptions;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Handlers.Commands;

public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, int>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public CreateBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(
        CreateBlogPostCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new BlogPostCreateDtoValidator();
        var validationResult = dtoValidator.Validate(request.BlogPostCreateDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);
        var blogPost = _mapper.Map<BlogPost>(request.BlogPostCreateDto);
        blogPost = await _blogPostRepository.Create(blogPost);

        return blogPost.Id;
    }
}
