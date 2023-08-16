using AutoMapper;
using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Queries;
using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Handlers.Queries;

public class GetBlogPostListRequestHandler
    : IRequestHandler<GetBlogPostListRequest, List<BlogPostListDto>>
{
    private readonly IBlogPostRepository _blogPostRepository;
    private readonly IMapper _mapper;

    public GetBlogPostListRequestHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
    {
        _blogPostRepository = blogPostRepository;
        _mapper = mapper;
    }

    public async Task<List<BlogPostListDto>> Handle(
        GetBlogPostListRequest request,
        CancellationToken cancellationToken
    )
    {
        var blogPosts = await _blogPostRepository.GetAll();
        return _mapper.Map<List<BlogPostListDto>>(blogPosts);
    }
}
