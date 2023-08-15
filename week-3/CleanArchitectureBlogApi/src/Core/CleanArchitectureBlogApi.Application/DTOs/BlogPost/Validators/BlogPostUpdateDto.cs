using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.BlogPost.Validators;

public class BlogPostUpdateDtoValidator : AbstractValidator<BlogPostUpdateDto>
{
    public BlogPostUpdateDtoValidator() {
      Include(new IBlogPostDtoValidator());
    }
}
