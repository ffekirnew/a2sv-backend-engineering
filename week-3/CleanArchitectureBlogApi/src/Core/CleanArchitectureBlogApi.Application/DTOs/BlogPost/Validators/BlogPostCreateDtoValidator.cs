using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.BlogPost.Validators;

public class BlogPostCreateDtoValidator : AbstractValidator<BlogPostCreateDto>
{
    public BlogPostCreateDtoValidator()
    {
        Include(new IBlogPostDtoValidator());
    }
}
