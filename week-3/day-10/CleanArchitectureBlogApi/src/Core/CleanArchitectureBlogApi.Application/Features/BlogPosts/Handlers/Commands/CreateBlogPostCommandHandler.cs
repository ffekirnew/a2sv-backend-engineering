using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Commands;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
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
        var blogPost = _mapper.Map<BlogPost>(request.BlogPostDto);
        blogPost = await _blogPostRepository.Create(blogPost);

        return blogPost.Id;
    }
}
