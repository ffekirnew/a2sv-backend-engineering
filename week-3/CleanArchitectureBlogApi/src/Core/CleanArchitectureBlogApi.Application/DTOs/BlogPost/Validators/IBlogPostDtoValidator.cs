using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.BlogPost.Validators;

public class IBlogPostDtoValidator : AbstractValidator<IBlogPostDto>
{
    public IBlogPostDtoValidator()
    {
        RuleFor(bP => bP.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50)
            .WithMessage("{PropertyName} must not exceed 50 characters.")
            .MinimumLength(5)
            .WithMessage("{PropertyName} must be at least 5 characters.");

        RuleFor(bP => bP.Content)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(1000)
            .WithMessage("{PropertyName} must not exceed 1000 characters.")
            .MinimumLength(50)
            .WithMessage("{PropertyName} must be at least 50 characters.");
    }
}
