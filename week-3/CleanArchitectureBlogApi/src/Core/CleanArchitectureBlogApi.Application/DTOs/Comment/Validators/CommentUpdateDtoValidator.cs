using CleanArchtectureBlogApi.Application.DTOs.Comment;
using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.Common.Validators;

public class CommentUpdateDtoValidator : AbstractValidator<CommentUpdateDto>
{
    public CommentUpdateDtoValidator()
    {
        RuleFor(c => c.PostId).GreaterThan(0).WithMessage("{PropertyName} must be a valid Id.");
        RuleFor(c => c.Text)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(1000)
            .WithMessage("{PropertyName} must not exceed 1000 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");
    }
}
