using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
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
        var blogPost = _mapper.Map<BlogPost>(request.BlogPostUpdateDto);
        await _blogPostRepository.Update(request.Id, blogPost);

        return Unit.Value;
    }
}
