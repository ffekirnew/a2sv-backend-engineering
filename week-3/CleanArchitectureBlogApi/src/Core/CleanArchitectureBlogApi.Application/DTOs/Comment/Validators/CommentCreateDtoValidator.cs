using CleanArchtectureBlogApi.Application.Contracts.Persistence;
using FluentValidation;

namespace CleanArchtectureBlogApi.Application.DTOs.Comment.Validators;

public class CommentCreateDtoValidator : AbstractValidator<CommentCreateDto>
{
    private IBlogPostRepository _blogPostRepository;

    public CommentCreateDtoValidator(IBlogPostRepository blogPostRepository)
    {
        _blogPostRepository = blogPostRepository;
        Include(new ICommentDtoValidator());

        RuleFor(c => c.PostId)
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be a valid Id.")
            .MustAsync(
                async (id, token) =>
                {
                    var commentExists = await _blogPostRepository.Exists(id);
                    return !commentExists;
                }
            );

        RuleFor(c => c.Text)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(1000)
            .WithMessage("{PropertyName} must not exceed 1000 characters.")
            .MinimumLength(3)
            .WithMessage("{PropertyName} must be at least 3 characters.");
    }
}
