using AutoMapper;
using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Queries;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Handlers.Queries;

public class GetBlogPostDetailRequestHandler
    : IRequestHandler<GetBlogPostDetailRequest, BlogPostDto>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public GetBlogPostDetailRequestHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<BlogPostDto> Handle(
        GetBlogPostDetailRequest request,
        CancellationToken cancellationToken
    )
    {
        var blogPost = await _blogPostRepository.Get(request.Id);
        return _mapper.Map<BlogPostDto>(blogPost);
    }
}
