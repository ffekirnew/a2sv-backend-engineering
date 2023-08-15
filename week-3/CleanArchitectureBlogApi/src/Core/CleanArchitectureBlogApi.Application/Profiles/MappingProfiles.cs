using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using CleanArchtectureBlogApi.Application.DTOs.Comment;

namespace HRLeaveManagement.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // BlogPost maps
        CreateMap<BlogPost, BlogPostListDto>();
        CreateMap<BlogPost, BlogPostDto>();
        CreateMap<BlogPost, BlogPostCreateDto>();

        // Comment maps
        CreateMap<Comment, CommentListDto>();
        CreateMap<Comment, CommentDto>();
        CreateMap<Comment, CommentCreateDto>();
    }
}
