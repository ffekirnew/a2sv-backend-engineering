using CleanArchtectureBlogApi.Application.DTOs.Comment;
using CleanArchtectureBlogApi.Application.Persistence.Contract;
using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.Common.Validators;

public class CommentUpdateDtoValidator : AbstractValidator<CommentUpdateDto>
{
    public readonly IBlogPostRepository _blogPostRepository;

    public CommentUpdateDtoValidator(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;

        RuleFor(c => c.PostId)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be a valid Id.")
            .MustAsync(
                async (id, token) =>
                {
                    var commentExists = await _blogPostRepository.Exists(id);
                    return !commentExists;
                }
            )
            .WithMessage("{PropertyName} doesn't exist.");

        RuleFor(c => c.Text)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(1000)
            .WithMessage("{PropertyName} must not exceed 1000 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");
    }
}
