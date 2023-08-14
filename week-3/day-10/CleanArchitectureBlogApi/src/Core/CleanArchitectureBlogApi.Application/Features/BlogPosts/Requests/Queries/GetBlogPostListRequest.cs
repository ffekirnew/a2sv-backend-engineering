using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using MediatR;

namespace CleanArchtectureBlogApi.Application.Features.BlogPosts.Requests.Queries;

public class GetBlogPostListRequest : IRequest<List<BlogPostDto>> { }
