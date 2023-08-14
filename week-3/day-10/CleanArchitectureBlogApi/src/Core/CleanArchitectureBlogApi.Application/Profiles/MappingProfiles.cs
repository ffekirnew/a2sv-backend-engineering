using AutoMapper;
using CleanArchitectureBlogApi.Domain.Entities;
using CleanArchtectureBlogApi.Application.DTOs.BlogPost;
using CleanArchtectureBlogApi.Application.DTOs.Comment;

namespace HRLeaveManagement.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BlogPost, BlogPostDto>();
        CreateMap<Comment, CommentDto>();
    }
}
