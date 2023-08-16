using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.Exceptions;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Handlers.Commands;

public class DeleteBlogPostCommandHandler : IRequestHandler<DeleteBlogPostCommand, Unit>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public DeleteBlogPostCommandHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(
        DeleteBlogPostCommand request,
        CancellationToken cancellationToken
    )
    {
        var blogPost = await _blogPostRepository.Get(request.Id);
        if (blogPost == null)
            throw new NotFoundException(nameof(BlogPost), request.Id);
        await _blogPostRepository.Delete(request.Id);
        return Unit.Value;
    }
}
