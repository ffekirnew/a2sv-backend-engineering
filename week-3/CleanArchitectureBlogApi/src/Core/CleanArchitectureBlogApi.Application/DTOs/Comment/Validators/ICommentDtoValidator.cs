using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.Comment.Validators;

public class ICommentDtoValidator : AbstractValidator<ICommentDto>
{
    public ICommentDtoValidator()
    {
        RuleFor(c => c.Text)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(1000)
            .WithMessage("{PropertyName} must not exceed 1000 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");
    }
}
